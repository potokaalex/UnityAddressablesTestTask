using Client.Common.Data;

namespace Client.Common.Services.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public void Initialize(ProjectConfig projectConfig) => Project = projectConfig;

        public ProjectConfig Project { get; private set; }
    }
}