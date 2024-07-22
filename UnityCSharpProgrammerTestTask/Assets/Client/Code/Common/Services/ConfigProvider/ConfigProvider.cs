using Client.Common.Data;
using Client.Common.Services.AssetLoader;

namespace Client.Common.Services.ConfigProvider
{
    public class ConfigProvider : IConfigProvider, IAssetReceiver
    {
        public ProjectConfig Configs { get; private set; }

        public void Receive(object asset)
        {
            if (asset.GetType() == typeof(ProjectConfig))
                Configs = (ProjectConfig)asset;
        }
    }
}