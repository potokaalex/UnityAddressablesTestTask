namespace Client.Common.Services.AssetLoader
{
    public interface IAssetReceiver<in T> : IAssetReceiverBase
    {
        //Dont rename, this method used in reflection! 
        void Receive(T asset);
    }
}