using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public class AssetLoader : IAssetLoader
    {
        private readonly Dictionary<IAssetReceiver, Type> _receivers = new();
        private readonly AssetLabelReference _projectLabel;

        public AssetLoader(AssetLabelReference projectLabel) => _projectLabel = projectLabel;

        public async UniTask LoadProject() => await LoadAssets(_projectLabel);

        public async UniTask LoadAssets(AssetLabelReference label, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            await Addressables.LoadAssetsAsync<object>(label, CallReceivers).ToUniTask(progress: progress);
        }

        public void RegisterReceiver(IAssetReceiver receiver) => _receivers[receiver] = GetGenericType(receiver);

        public void UnRegisterReceiver(IAssetReceiver receiver) => _receivers.Remove(receiver);

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