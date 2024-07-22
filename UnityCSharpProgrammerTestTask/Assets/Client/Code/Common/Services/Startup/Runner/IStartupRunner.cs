using UnityEngine.SceneManagement;

namespace Client.Common.Services.Startup.Runner
{
    public interface IStartupRunner
    {
        void Run(Scene scene);
    }
}