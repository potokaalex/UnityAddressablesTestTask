using Client.Code.MiniGame2.Data;
using Client.Common.Services.AssetLoader;

namespace Client.Code.MiniGame2
{
    public class MiniGame2Factory : IAssetReceiver<MiniGame2Config>
    {
        private MiniGame2Config _config;

        public void CreateWinWindow()
        {
            
        }
        
        public void CreateDefeatWindow()
        {
            
        }

        public void Receive(MiniGame2Config asset) => _config = asset;
    }
}