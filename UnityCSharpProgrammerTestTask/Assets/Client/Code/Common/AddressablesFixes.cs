using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Client.Common
{
public class AddressablesFixes : MonoBehaviour
    {
        /// <summary>
        /// This is a workaround the broken Addressables method. If Addressable Package is updated this method could break, or in the best case become obsolete.
        /// </summary>
        /// <param name="key"></param>
        public static AsyncOperationHandle ClearDependencyCacheForKey(object key)
        {
            AsyncOperationHandle initHandle = Addressables.InitializeAsync();
            if (initHandle.IsDone)
            {
                ClearDependencyCacheForKeyInternal(key);
            }
            else
            {
                initHandle.Completed += (handle) =>
                {
                    ClearDependencyCacheForKeyInternal(key);
                };
            }
            return initHandle;
        }

        private static void ClearDependencyCacheForKeyInternal(object key)
        {
#if ENABLE_CACHING
            IList<IResourceLocation> locations;
            if (key is IResourceLocation resourceLocation && resourceLocation.HasDependencies)
            {
                foreach (var dep in resourceLocation.Dependencies)
                {
                    if (dep.Data is AssetBundleRequestOptions options)
                    {
                        ClearCacheForBundle(options.BundleName);
                    }
                }
            }
            else if (GetResourceLocations(key, typeof(object), out locations))
            {
                foreach (var dep in GatherDependenciesFromLocations(locations))
                {
                    if (dep.Data is AssetBundleRequestOptions options)
                    {
                        ClearCacheForBundle(options.BundleName);
                    }
                }
            }
#endif
        }

        private static void ClearCacheForBundle(string bundleName)
        {
            List<Hash128> hashList = new List<Hash128>();
            Caching.GetCachedVersions(bundleName, hashList);
            foreach (Hash128 hash in hashList)
            {
                Caching.ClearCachedVersion(bundleName, hash);
            }
        }

        static private List<IResourceLocation> GatherDependenciesFromLocations(IList<IResourceLocation> locations)
        {
            var locHash = new HashSet<IResourceLocation>();
            foreach (var loc in locations)
            {
                if (loc.ResourceType == typeof(IAssetBundleResource))
                {
                    locHash.Add(loc);
                }
                if (loc.HasDependencies)
                {
                    foreach (var dep in loc.Dependencies)
                        if (dep.ResourceType == typeof(IAssetBundleResource))
                            locHash.Add(dep);
                }
            }
            return new List<IResourceLocation>(locHash);
        }

        private static bool GetResourceLocations(object key, Type type, out IList<IResourceLocation> locations)
        {
            key = EvaluateKey(key);

            locations = null;
            HashSet<IResourceLocation> current = null;
            foreach (var locatorInfo in Addressables.ResourceLocators)
            {
                var locator = locatorInfo;
                IList<IResourceLocation> locs;
                if (locator.Locate(key, type, out locs))
                {
                    if (locations == null)
                    {
                        //simple, common case, no allocations
                        locations = locs;
                    }
                    else
                    {
                        //less common, need to merge...
                        if (current == null)
                        {
                            current = new HashSet<IResourceLocation>();
                            foreach (var loc in locations)
                                current.Add(loc);
                        }

                        current.UnionWith(locs);
                    }
                }
            }

            if (current == null)
                return locations != null;

            locations = new List<IResourceLocation>(current);
            return true;
        }

        private static object EvaluateKey(object obj)
        {
            if (obj is IKeyEvaluator)
                return (obj as IKeyEvaluator).RuntimeKey;
            return obj;
        }
    }
}