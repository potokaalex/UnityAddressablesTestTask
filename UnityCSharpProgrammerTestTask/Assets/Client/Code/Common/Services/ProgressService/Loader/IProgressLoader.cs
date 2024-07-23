using System;
using Cysharp.Threading.Tasks;

namespace Client.Common.Services.ProgressService.Loader
{
    public interface IProgressLoader
    {
        UniTask Load(Action<float> progressReceiver = null);
        void Register(IProgressReader reader);
        void UnRegister(IProgressReader reader);
    }
}