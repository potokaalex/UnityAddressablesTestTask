using Client.Common.Data;

namespace Client.Common.Services.StaticDataProvider
{
    public interface IStaticDataProvider
    {
        void Initialize(ProjectConfig projectConfig);
        ProjectConfig Project { get; }
    }
}