using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask<Scene> LoadSceneAsync(AssetReference key)
        {
            var sceneInstance = await Addressables.LoadSceneAsync(key).ToUniTask();
            await UniTask.Yield();
            return sceneInstance.Scene;
        }
    }
}