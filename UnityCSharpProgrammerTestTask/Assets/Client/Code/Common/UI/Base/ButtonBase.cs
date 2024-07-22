using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Common.UI.Base
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public abstract class ButtonBase : MonoBehaviour, IUIElement
    {
        private Button _button;
        private IButtonsHandler _handler;

        [Inject]
        public void BaseConstruct(IButtonsHandler handler) => _handler = handler;

        public virtual ButtonType GetBaseType() => 0;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private protected virtual void OnDestroy() => _button.onClick.RemoveListener(OnClick);

        private protected virtual void OnClick() => _handler.Handle(this);
    }
}