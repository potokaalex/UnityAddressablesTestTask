using UniRx;

namespace Client.MiniGame1.Gameplay.Player.UI
{
    public class PlayerModel
    {
        public ReactiveProperty<float> Score { get; private set; } = new();
    }
}