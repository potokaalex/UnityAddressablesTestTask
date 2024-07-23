using Client.Common.Data.Progress;
using Client.Common.Services.ProgressService.Loader;
using Client.Common.Services.ProgressService.Saver;
using UniRx;

namespace Client.MiniGame1.Gameplay.Player.UI
{
    public class PlayerModel : IProgressReader, IProgressWriter
    {
        public ReactiveProperty<float> Score { get; private set; }
        
        public void OnLoad(ProgressData progress) => Score = new ReactiveProperty<float>(progress.MiniGame1.Score);

        public void OnSave(ProgressData progress) => progress.MiniGame1.Score = Score.Value;
    }
}