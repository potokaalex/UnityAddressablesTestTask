using Client.Common.Data;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Common.Services.AssetLoader
{
    public interface IAssetLoader
    {
        UniTask<ProjectConfig> LoadProject();
        UniTask<T> LoadAssetAsync<T>(object key);
    }
}