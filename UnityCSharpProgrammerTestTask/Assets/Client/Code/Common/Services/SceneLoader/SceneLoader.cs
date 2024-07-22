using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly List<GameObject> _sceneRootObjects = new();

        public async UniTask<Scene> LoadSceneAsync(AssetReference key)
        {
            var sceneInstance = await Addressables.LoadSceneAsync(key).ToUniTask();
            await UniTask.Yield();
            return sceneInstance.Scene;
        }

        public T FindInScene<T>(string sceneName)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            scene.GetRootGameObjects(_sceneRootObjects);

            foreach (var rootObject in _sceneRootObjects)
                if (rootObject.TryGetComponent<T>(out var obj))
                    return obj;

            throw new Exception($"Cant find {typeof(T).Name} on {sceneName} scene");
        }
    }
}