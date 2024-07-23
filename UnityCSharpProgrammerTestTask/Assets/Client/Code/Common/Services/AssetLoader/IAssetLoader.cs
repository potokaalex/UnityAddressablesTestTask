using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public interface IAssetLoader
    {
        UniTask LoadProject();
        UniTask LoadAssets(AssetLabel label, Action<float> progressReceiver = null);
        void RegisterReceiver(IAssetReceiverBase receiver);
        void UnRegisterReceiver(IAssetReceiverBase receiver);
    }
}