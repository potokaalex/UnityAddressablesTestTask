using System;
using System.Collections.Generic;
using Zenject;

namespace Client.Common.Services.AssetLoader
{
    public class AssetReceiverRegister : IInitializable, IDisposable
    {
        private readonly List<IAssetReceiverBase> _receivers;
        private readonly IAssetLoader _assetLoader;

        public AssetReceiverRegister(List<IAssetReceiverBase> receivers, IAssetLoader assetLoader)
        {
            _receivers = receivers;
            _assetLoader = assetLoader;
        }
        
        public void Initialize()
        {
            foreach (var receiver in _receivers) 
                _assetLoader.RegisterReceiver(receiver);    
        }

        public void Dispose()
        {
            foreach (var receiver in _receivers) 
                _assetLoader.UnRegisterReceiver(receiver);    
        }
    }
}