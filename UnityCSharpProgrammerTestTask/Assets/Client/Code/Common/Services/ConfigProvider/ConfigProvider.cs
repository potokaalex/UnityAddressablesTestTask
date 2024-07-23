using Client.Common.Data;
using Client.Common.Services.AssetLoader;

namespace Client.Common.Services.ConfigProvider
{
    public class ConfigProvider : IConfigProvider, IAssetReceiver
    {
        public ProjectConfig Project { get; private set; }

        public void Receive(object asset)
        {
            if (asset.GetType() == typeof(ProjectConfig))
                Project = (ProjectConfig)asset;
        }
    }
}