using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Common.UI.Button.Base
{
    [RequireComponent(typeof(Image), typeof(UnityEngine.UI.Button))]
    public abstract class ButtonBase : MonoBehaviour, IUIElement
    {
        private UnityEngine.UI.Button _button;
        private IButtonsHandler _handler;

        [Inject]
        public void BaseConstruct(IButtonsHandler handler) => _handler = handler;

        public virtual ButtonType GetBaseType() => 0;

        protected virtual void Awake()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            _button.onClick.AddListener(OnClick);
        }

        private protected virtual void OnDestroy() => _button.onClick.RemoveListener(OnClick);

        private protected virtual void OnClick() => _handler.Handle(this);
    }
}