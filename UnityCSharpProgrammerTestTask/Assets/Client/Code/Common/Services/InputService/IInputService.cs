namespace Client.Common.Services.InputService
{
    public interface IInputService
    {
        bool IsMouseButtonDown(MouseType type);
        bool IsPointerOverGameObject();
        void Initialize(InputServiceObject serviceObject);
    }
}