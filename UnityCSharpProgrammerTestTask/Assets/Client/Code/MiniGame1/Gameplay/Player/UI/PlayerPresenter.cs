using UniRx;

namespace Client.MiniGame1.Gameplay.Player.UI
{
    public class PlayerPresenter
    {
        private readonly PlayerModel _model;

        public PlayerPresenter(PlayerModel model) => _model = model;

        public void Initialize(PlayerCanvas playerCanvas) => _model.Score.Subscribe(v => playerCanvas.ScoreBar.Set(v));
    }
}