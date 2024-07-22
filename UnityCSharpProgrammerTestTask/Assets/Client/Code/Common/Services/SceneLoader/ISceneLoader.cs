﻿using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask<Scene> LoadSceneAsync(AssetReference key);
        T FindInScene<T>(string sceneName);
    }
}