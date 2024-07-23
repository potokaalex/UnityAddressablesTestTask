using System;
using System.Collections.Generic;
using Client.Common.Services.ProgressService.Loader;
using Client.Common.Services.ProgressService.Saver;
using Zenject;

namespace Client.Common.Services.ProgressService
{
    public class ProgressActorsRegister : IInitializable, IDisposable
    {
        private readonly IProgressSaver _saver;
        private readonly IProgressLoader _loader;
        private readonly List<IProgressReader> _readers;
        private readonly List<IProgressWriter> _writers;

        public ProgressActorsRegister(IProgressSaver saver, IProgressLoader loader, List<IProgressReader> readers, List<IProgressWriter> writers)
        {
            _saver = saver;
            _loader = loader;
            _readers = readers;
            _writers = writers;
        }

        public void Initialize()
        {
            foreach (var reader in _readers)
                _loader.Register(reader);

            foreach (var writer in _writers)
                _saver.Register(writer);
        }

        public void Dispose()
        {
            foreach (var reader in _readers)
                _loader.UnRegister(reader);

            foreach (var writer in _writers)
                _saver.UnRegister(writer);
        }
    }
}