using System;

namespace Client.Common.Services.Updater
{
    public interface IUpdater
    {
        event Action OnUpdate;
        event Action OnFixedUpdate;
        event Action OnProjectExit;
    }
}