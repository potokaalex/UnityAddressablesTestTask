using Client.Common.Data;
using Cysharp.Threading.Tasks;

namespace Client.Common.Services.AssetLoader
{
    public interface IAssetLoader
    {
        UniTask<ProjectConfig> LoadProject();
    }
}