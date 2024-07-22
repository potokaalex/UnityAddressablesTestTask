using System.Collections.Generic;
using Client.Common.Data;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public class AssetLoader : IAssetLoader
    {
        private readonly AssetReference _projectConfig;
        private readonly List<IAssetReceiver> _receivers = new();

        public AssetLoader(AssetReference projectConfig) => _projectConfig = projectConfig;

        public async UniTask LoadProject()
        {
            var asset = await Addressables.LoadAssetAsync<ProjectConfig>(_projectConfig).ToUniTask();
            CallReceivers(asset);
        }

        public async UniTask LoadAssets(AssetLabelReference label) => await Addressables.LoadAssetsAsync<object>(label, CallReceivers);

        public void RegisterReceiver(IAssetReceiver receiver) => _receivers.Add(receiver);

        public void UnRegisterReceiver(IAssetReceiver receiver) => _receivers.Remove(receiver);

        private void CallReceivers(object asset)
        {
            foreach (var receiver in _receivers)
                receiver.Receive(asset);
        }
    }
}