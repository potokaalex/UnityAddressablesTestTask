using System;
using System.Collections.Generic;
using Client.Common.Data;
using Client.Common.Data.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public class AssetLoader : IAssetLoader, IAssetReceiver<ProjectConfig>
    {
        private readonly Dictionary<IAssetReceiverBase, Type> _receivers = new();
        private readonly AssetLabelReference _projectLabel;
        private ProjectConfig _config;

        public AssetLoader(AssetLabelReference projectLabel) => _projectLabel = projectLabel;

        public async UniTask LoadProject() => await LoadAssets(_projectLabel);

        public async UniTask LoadAssets(AssetLabel label, Action<float> progressReceiver = null) =>
            await LoadAssets(_config.Labels.Keys[label], progressReceiver);

        public async UniTask LoadAssets(AssetLabelReference label, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            await Addressables.LoadAssetsAsync<object>(label, CallReceivers).ToUniTask(progress: progress);
        }

        public void RegisterReceiver(IAssetReceiverBase receiver) => _receivers[receiver] = GetGenericType(receiver);

        public void UnRegisterReceiver(IAssetReceiverBase receiver) => _receivers.Remove(receiver);

        public void Receive(ProjectConfig asset) => _config = asset;

        private void CallReceivers(object asset)
        {
            foreach (var receiver in _receivers)
            {
                if (asset.GetType() == receiver.Value)
                {
                    var method = receiver.Key.GetType().GetMethod("Receive");
                    method?.Invoke(receiver.Key, new[] { Convert.ChangeType(asset, receiver.Value) });
                }
            }
        }

        private Type GetGenericType(object instance)
        {
            var interfaces = instance.GetType().GetInterfaces();

            foreach (var i in interfaces)
                if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAssetReceiver<>))
                    return i.GetGenericArguments()[0];

            return null;
        }
    }
}