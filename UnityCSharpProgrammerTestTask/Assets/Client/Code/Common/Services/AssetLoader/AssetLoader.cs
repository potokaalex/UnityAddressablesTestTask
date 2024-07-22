using Client.Common.Data;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public class AssetLoader : IAssetLoader
    {
        private readonly AssetReference _projectConfig;

        public AssetLoader(AssetReference projectConfig) => _projectConfig = projectConfig;

        public async UniTask<ProjectConfig> LoadProject() => await Addressables.LoadAssetAsync<ProjectConfig>(_projectConfig).ToUniTask();
    }
}