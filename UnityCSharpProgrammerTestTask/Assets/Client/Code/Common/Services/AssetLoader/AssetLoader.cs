using System;
using System.Collections.Generic;
using Client.Common.Data.Configs;
using Client.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public class AssetLoader : IAssetLoader, IAssetReceiver<ProjectConfig>
    {
        private readonly Dictionary<IAssetReceiverBase, Type> _receivers = new();
        private readonly AssetLabelReference _projectLabel;
        private readonly ILogReceiver _logReceiver;
        private ProjectConfig _config;

        public AssetLoader(AssetLabelReference projectLabel, ILogReceiver logReceiver)
        {
            _projectLabel = projectLabel;
            _logReceiver = logReceiver;
        }

        public async UniTask<bool> LoadProject() => await LoadAssets(_projectLabel);

        //BUG dont update progressReceiver!
        public async UniTask<bool> LoadAssets(AssetLabel label, Action<float> progressReceiver = null) =>
            await LoadAssets(_config.Labels.Keys[label], progressReceiver);

        public void UnloadAssets(AssetLabel label)
        {
            //Addressables.rel
            Addressables.ClearDependencyCacheAsync(_config.Labels.Keys[label]);
        }

        public void RegisterReceiver(IAssetReceiverBase receiver) => _receivers[receiver] = GetGenericType(receiver);

        public void UnRegisterReceiver(IAssetReceiverBase receiver) => _receivers.Remove(receiver);

        public void Receive(ProjectConfig asset) => _config = asset;

        private async UniTask<bool> LoadAssets(AssetLabelReference label, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            try
            {
                await Addressables.LoadAssetsAsync<object>(label, CallReceivers, true).ToUniTask(progress: progress);
            }
            catch(Exception exception)
            {
                _logReceiver.Log(new LogData {Message = exception.Message});
                return false;
            }

            return true;
        }
        
        private void CallReceivers(object asset)
        {
            if(asset == null)
                return;
            
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