using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask<Scene> LoadSceneAsync(AssetReference key, Action<float> progressReceiver = null);
    }
}