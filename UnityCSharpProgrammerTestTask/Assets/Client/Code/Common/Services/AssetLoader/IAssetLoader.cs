using System;
using Cysharp.Threading.Tasks;

namespace Client.Common.Services.AssetLoader
{
    public interface IAssetLoader
    {
        UniTask<bool> LoadProject();
        UniTask<bool> LoadAssets(AssetLabelType label, Action<float> progressReceiver = null);
        void UnloadAssets(AssetLabelType label);
        UniTask ClearAssets(AssetLabelType label);
        void RegisterReceiver(IAssetReceiverBase receiver);
        void UnRegisterReceiver(IAssetReceiverBase receiver);
    }
}