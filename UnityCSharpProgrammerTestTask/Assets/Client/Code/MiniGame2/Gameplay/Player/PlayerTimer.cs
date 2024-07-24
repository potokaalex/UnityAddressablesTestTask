using System.Diagnostics;
using Client.Common.Data.Progress;
using Client.Common.Services.ProgressService.Loader;
using Client.Common.Services.ProgressService.Saver;
using UniRx;

namespace Client.Code.MiniGame2.Gameplay.Player
{
    public class PlayerTimer : IProgressReader, IProgressWriter
    {
        private readonly PlayerController _controller;
        private readonly Stopwatch _stopwatch = new();

        public PlayerTimer(PlayerController controller) => _controller = controller;

        public ReactiveProperty<float> CurrentTimeMs { get; } = new();

        public ReactiveProperty<float> BestTimeMs { get; private set; }

        public void Start() => _stopwatch.Start();

        public void OnUpdate() => CurrentTimeMs.Value = (float)_stopwatch.Elapsed.TotalMilliseconds;

        public void Stop()
        {
            _stopwatch.Stop();
            OnUpdate();
            
            if (CurrentTimeMs.Value < BestTimeMs.Value || BestTimeMs.Value == 0)
                if(_controller.IsWin)
                    BestTimeMs.Value = CurrentTimeMs.Value;
        }

        public void OnSave(ProgressData progress) => progress.MiniGame2.BestTimeMs = BestTimeMs.Value;

        public void OnLoad(ProgressData progress) => BestTimeMs = new ReactiveProperty<float>(progress.MiniGame2.BestTimeMs);
    }
}