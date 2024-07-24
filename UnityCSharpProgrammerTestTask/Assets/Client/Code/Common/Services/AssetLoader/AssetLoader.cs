using System;
using System.Collections.Generic;
using Client.Common.Data.Configs;
using Client.Common.Services.Logger.Base;
using Client.Common.Utilities;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Client.Common.Services.AssetLoader
{
    public class AssetLoader : IAssetLoader, IAssetReceiver<ProjectConfig>
    {
        private readonly Dictionary<IAssetReceiverBase, Type> _receivers = new();
        private readonly Dictionary<AssetLabelReference, AsyncOperationHandle<IList<object>>> _handles = new();
        private readonly AssetLabelReference _projectLabel;
        private readonly ILogReceiver _logReceiver;
        private ProjectConfig _config;

        public AssetLoader(AssetLabelReference projectLabel, ILogReceiver logReceiver)
        {
            _projectLabel = projectLabel;
            _logReceiver = logReceiver;
        }

        public async UniTask<bool> LoadProject()
        {
            await Addressables.InitializeAsync(false);
            return await LoadAssets(_projectLabel);
        }

        public async UniTask<bool> LoadAssets(AssetLabelType label, Action<float> progressReceiver = null) =>
            await LoadAssets(_config.Labels.Keys[label], progressReceiver);

        public void UnloadAssets(AssetLabelType label)
        {
            var labelReference = _config.Labels.Keys[label];
            _handles[labelReference].Release();
            //_handles.Remove(labelReference);
        }

        public UniTask ClearAssets(AssetLabelType label) => AddressablesFixes.ClearDependencyCacheForKey(_config.Labels.Keys[label]).ToUniTask();

        public void RegisterReceiver(IAssetReceiverBase receiver) => _receivers[receiver] = GetGenericType(receiver);

        public void UnRegisterReceiver(IAssetReceiverBase receiver) => _receivers.Remove(receiver);

        public void Receive(ProjectConfig asset) => _config = asset;

        private async UniTask<bool> LoadAssets(AssetLabelReference label, Action<float> progressReceiver = null)
        {
            var progress = Progress.Create(progressReceiver);
            try
            {
                var handle = Addressables.LoadAssetsAsync<object>(label, CallReceivers, true);
                _handles[label] = handle;
                await handle.ToUniTask(progress: progress); //BUG dont update progress!
            }
            catch (Exception exception)
            {
                _logReceiver.Log(new LogData { Message = exception.Message });
                return false;
            }

            return true;
        }

        private void CallReceivers(object asset)
        {
            if (asset == null)
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