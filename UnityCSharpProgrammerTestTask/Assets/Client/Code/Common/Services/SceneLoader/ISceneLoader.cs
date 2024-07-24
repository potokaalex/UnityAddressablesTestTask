using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask<(Scene, bool)> LoadSceneAsync(SceneName name, Action<float> progressReceiver = null);
        UniTask ClearScene(SceneName name);
    }
}