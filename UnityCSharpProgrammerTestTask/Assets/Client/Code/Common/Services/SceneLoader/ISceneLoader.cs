using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask<Scene> LoadSceneAsync(SceneName name, Action<float> progressReceiver = null);
    }
}