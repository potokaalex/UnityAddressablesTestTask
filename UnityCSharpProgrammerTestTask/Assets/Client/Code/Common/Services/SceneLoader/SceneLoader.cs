using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask<Scene> LoadSceneAsync(AssetReference key, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            var sceneInstance = await Addressables.LoadSceneAsync(key).ToUniTask(progress: progress);
            await UniTask.Yield();
            return sceneInstance.Scene;
        }
    }
}