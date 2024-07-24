using System;
using Cysharp.Threading.Tasks;

namespace Client.Common.Services.AssetLoader
{
    public interface IAssetLoader
    {
        UniTask LoadProject();
        UniTask<bool> LoadAssets(AssetLabel label, Action<float> progressReceiver = null);
        void UnloadAssets(AssetLabel label);
        void RegisterReceiver(IAssetReceiverBase receiver);
        void UnRegisterReceiver(IAssetReceiverBase receiver);
    }
}