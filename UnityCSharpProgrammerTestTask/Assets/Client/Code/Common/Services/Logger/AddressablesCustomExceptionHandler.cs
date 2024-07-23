using System;
using Client.Common.Services.Logger.Base;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Client.Common.Services.Logger
{
    public class AddressablesCustomExceptionHandler : IInitializable
    {
        private readonly ILogReceiver _logReceiver;

        public AddressablesCustomExceptionHandler(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public void Initialize() => ResourceManager.ExceptionHandler = Handle;

        private void Handle(AsyncOperationHandle handle, Exception exception) => _logReceiver.Log(new LogData { Message = exception.Message });
    }
}