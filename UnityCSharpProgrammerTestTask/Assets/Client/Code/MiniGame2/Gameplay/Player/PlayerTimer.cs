using System.Diagnostics;
using Client.Common.Data.Progress;
using Client.Common.Services.ProgressService.Loader;
using Client.Common.Services.ProgressService.Saver;
using UniRx;

namespace Client.Code.MiniGame2.Gameplay.Player
{
    public class PlayerTimer : IProgressReader, IProgressWriter
    {
        private readonly Stopwatch _stopwatch = new();

        public ReactiveProperty<float> CurrentScoreMs { get; } = new();
        
        public float BestScoreMs { get; private set; }
        
        public void Start() => _stopwatch.Start();

        public void OnUpdate() => CurrentScoreMs.Value = (float)_stopwatch.Elapsed.TotalMilliseconds;

        public void Stop()
        {
            _stopwatch.Stop();
            OnUpdate();
        }

        public void OnSave(ProgressData progress)
        {
            if(CurrentScoreMs.Value > BestScoreMs)
                BestScoreMs = progress.MiniGame2.BestScoreMs;
        }

        public void OnLoad(ProgressData progress) => BestScoreMs = progress.MiniGame2.BestScoreMs;
    }
}