using System;
using System.Collections.Generic;
using System.IO;
using Client.Common.Data;
using Client.Common.Data.Progress;
using Client.Common.Services.Logger.Base;
using Client.Common.Services.ProgressService.Loader;
using UnityEngine;

namespace Client.Common.Services.ProgressService.Saver
{
    public class ProgressSaver : IProgressSaver, IProgressReader
    {
        private readonly ILogReceiver _logReceiver;
        private readonly List<IProgressWriter> _writers = new();
        private ProgressData _progress;

        public ProgressSaver(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public void Save()
        {
            foreach (var writer in _writers)
                writer.OnSave(_progress);

            SaveProgress();
        }

        private void SaveProgress()
        {
            if (!Directory.Exists(ProgressStorageConstants.DirectoryPath))
                Directory.CreateDirectory(ProgressStorageConstants.DirectoryPath);

            try
            {
                using var writer = new StreamWriter(ProgressStorageConstants.FilePath, false);
                writer.Write(JsonUtility.ToJson(_progress));
            }
            catch (Exception exception)
            {
                _logReceiver.Log(new LogData { Message = exception.Message });
            }
        }

        public void Register(IProgressWriter writer) => _writers.Add(writer);

        public void UnRegister(IProgressWriter writer) => _writers.Remove(writer);

        public void OnLoad(ProgressData progress) => _progress = progress;
    }
}