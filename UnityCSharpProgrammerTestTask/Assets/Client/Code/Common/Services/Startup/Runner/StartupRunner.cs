using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Common.Services.Startup.Runner
{
    public class StartupRunner : IStartupRunner
    {
        private readonly List<GameObject> _sceneRootObjects = new();

        public void Run(Scene scene)
        {
            scene.GetRootGameObjects(_sceneRootObjects);

            foreach (var rootObject in _sceneRootObjects)
            {
                if (rootObject.TryGetComponent<IStartuper>(out var startuper))
                {
                    startuper.Startup();
                    return;
                }
            }

            throw new Exception($"Cant find startupper on {scene.name} scene");
        }
    }
}