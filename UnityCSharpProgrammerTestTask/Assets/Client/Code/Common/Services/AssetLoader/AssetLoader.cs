using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public class AssetLoader : IAssetLoader
    {
        private readonly List<IAssetReceiver> _receivers = new();
        private readonly AssetLabelReference _projectLabel;

        public AssetLoader(AssetLabelReference projectLabel) => _projectLabel = projectLabel;

        public async UniTask LoadProject() => await LoadAssets(_projectLabel);

        public async UniTask LoadAssets(AssetLabelReference label, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            await Addressables.LoadAssetsAsync<object>(label, CallReceivers).ToUniTask(progress: progress);
        }

        public void RegisterReceiver(IAssetReceiver receiver) => _receivers.Add(receiver);

        public void UnRegisterReceiver(IAssetReceiver receiver) => _receivers.Remove(receiver);

        private void CallReceivers(object asset)
        {
            foreach (var receiver in _receivers)
                receiver.Receive(asset);
        }
    }
}