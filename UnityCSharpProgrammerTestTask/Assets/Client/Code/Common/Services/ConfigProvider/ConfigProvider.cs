using Client.Common.Data;
using Client.Common.Services.AssetLoader;

namespace Client.Common.Services.ConfigProvider
{
    public class ConfigProvider : IConfigProvider, IAssetReceiver<ProjectConfig>
    {
        public ProjectConfig Project { get; private set; }

        public void Receive(ProjectConfig asset) => Project = asset;
    }
}