using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public interface IAssetLoader
    {
        UniTask LoadProject();
        UniTask LoadAssets(AssetLabel label, Action<float> progressReceiver = null);
        void RegisterReceiver(IAssetReceiver receiver);
        void UnRegisterReceiver(IAssetReceiver receiver);
    }
}