using System;
using Client.Common.Data.Configs;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader, IAssetReceiver<ProjectConfig>
    {
        private readonly ILogReceiver _logReceiver;
        private ProjectConfig _config;

        public SceneLoader(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public UniTask<(Scene, bool)> LoadSceneAsync(SceneName name, Action<float> progressReceiver = null)
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

        private async UniTask<(Scene, bool)> LoadSceneAsync(AssetReference key, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            try
            {
                var sceneInstance = await Addressables.LoadSceneAsync(key).ToUniTask(progress: progress);
                await UniTask.Yield();
                return (sceneInstance.Scene, true);
            }
            catch (Exception exception)
            {
                _logReceiver.Log(new LogData { Message = exception.Message });
                return (default, false);
            }
        }
    }
}