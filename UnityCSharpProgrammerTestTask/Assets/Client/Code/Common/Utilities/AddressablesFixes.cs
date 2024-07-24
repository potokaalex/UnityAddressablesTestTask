using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Client.Common.Utilities
{
    //Taken from here:
    //https://discussions.unity.com/t/how-to-use-addressables-cleardependencycacheasync-where-lines/803226/14#:~:text=Aug%202020-,Update,-%3A
    
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
                initHandle.Completed += _ => { ClearDependencyCacheForKeyInternal(key); };
            }

            return initHandle;
        }

        private static void ClearDependencyCacheForKeyInternal(object key)
        {
#if ENABLE_CACHING
            if (key is IResourceLocation { HasDependencies: true } resourceLocation)
            {
                foreach (var dep in resourceLocation.Dependencies)
                {
                    if (dep.Data is AssetBundleRequestOptions options)
                    {
                        ClearCacheForBundle(options.BundleName);
                    }
                }
            }
            else if (GetResourceLocations(key, typeof(object), out var locations))
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

        private static List<IResourceLocation> GatherDependenciesFromLocations(IList<IResourceLocation> locations)
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
                if (locator.Locate(key, type, out var locs))
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
            if (obj is IKeyEvaluator evaluator)
                return evaluator.RuntimeKey;
            
            return obj;
        }
    }
}