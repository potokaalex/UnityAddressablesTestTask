using System;
using UnityEngine;

namespace Client.Common.Services.Updater
{
    public class Updater : MonoBehaviour, IUpdater
    {
        public event Action OnUpdate;
        public event Action OnFixedUpdate;
        public event Action OnProjectExit;

        private void Update() => OnUpdate?.Invoke();

        private void FixedUpdate() => OnFixedUpdate?.Invoke();

        private void OnDestroy() => OnProjectExit?.Invoke();
    }
}