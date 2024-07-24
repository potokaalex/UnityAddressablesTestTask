using System;
using System.Collections.Generic;
using Client.Common.Data.Configs;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader, IAssetReceiver<ProjectConfig>
    {
        private readonly Dictionary<AssetReference, AsyncOperationHandle<SceneInstance>> _handles = new();
        private readonly ILogReceiver _logReceiver;
        private ProjectConfig _config;

        public SceneLoader(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public UniTask<(Scene, bool)> LoadSceneAsync(SceneName name, Action<float> progressReceiver = null) =>
            LoadSceneAsync(GetReference(name), progressReceiver);

        public UniTask ClearScene(SceneName name) => AddressablesFixes.ClearDependencyCacheForKey(GetReference(name)).ToUniTask();

        public void Receive(ProjectConfig asset) => _config = asset;

        private AssetReference GetReference(SceneName name)
        {
            return name switch
            {
                SceneName.Hub => _config.Scenes.Hub,
                SceneName.MiniGame1 => _config.Scenes.MiniGame1,
                SceneName.MiniGame2 => _config.Scenes.MiniGame2,
                _ => throw new Exception($"Cant find key for scene {name}")
            };
        }

        private async UniTask<(Scene, bool)> LoadSceneAsync(AssetReference key, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            try
            {
                var handle = Addressables.LoadSceneAsync(key, releaseMode: SceneReleaseMode.ReleaseSceneWhenSceneUnloaded);
                _handles[key] = handle;
                var sceneInstance = await handle.ToUniTask(progress: progress);
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