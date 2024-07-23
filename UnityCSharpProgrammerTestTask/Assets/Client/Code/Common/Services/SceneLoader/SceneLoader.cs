using System;
using Client.Common.Data;
using Client.Common.Data.Configs;
using Client.Common.Services.AssetLoader;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader, IAssetReceiver<ProjectConfig>
    {
        private ProjectConfig _config;

        public UniTask<Scene> LoadSceneAsync(SceneName name, Action<float> progressReceiver = null)
        {
            if (name == SceneName.Hub)
                return LoadSceneAsync(_config.Scenes.Hub, progressReceiver);
            if (name == SceneName.MiniGame1)
                return LoadSceneAsync(_config.Scenes.MiniGame1, progressReceiver);
            if (name == SceneName.MiniGame2)
                return LoadSceneAsync(_config.Scenes.MiniGame2, progressReceiver);

            throw new Exception($"Cant find key for scene {name}");
        }

        public void Receive(ProjectConfig asset) => _config = asset;

        private async UniTask<Scene> LoadSceneAsync(AssetReference key, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            var sceneInstance = await Addressables.LoadSceneAsync(key).ToUniTask(progress: progress);
            await UniTask.Yield();
            return sceneInstance.Scene;
        }
    }
}