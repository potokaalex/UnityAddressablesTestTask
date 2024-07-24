using System;
using System.Collections.Generic;
using System.IO;
using Client.Common.Data;
using Client.Common.Data.Progress;
using Client.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Client.Common.Services.ProgressService.Loader
{
    public class ProgressLoader : IProgressLoader
    {
        private readonly ILogReceiver _logReceiver;
        private readonly List<IProgressReader> _readers = new();

        private ProgressLoader(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public async UniTask Load(Action<float> progressReceiver = null)
        {
            var progress = await LoadProgress();

            foreach (var reader in _readers)
                reader.OnLoad(progress);
            
            progressReceiver?.Invoke(1);
        }

        private async UniTask<ProgressData> LoadProgress()
        {
            var defaultProgress = new ProgressData();

            if (!File.Exists(ProgressStorageConstants.FilePath))
                return defaultProgress;

            try
            {
                using var reader = new StreamReader(ProgressStorageConstants.FilePath, false);
                var readData = await reader.ReadToEndAsync().AsUniTask();
                var result = JsonUtility.FromJson<ProgressData>(readData);
                if (result != null)
                    return result;
            }
            catch (Exception exception)
            {
                _logReceiver.Log(new LogData { Message = exception.Message });
            }

            return defaultProgress;
        }

        public void Register(IProgressReader reader) => _readers.Add(reader);

        public void UnRegister(IProgressReader reader) => _readers.Remove(reader);
    }
}