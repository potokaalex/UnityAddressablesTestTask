namespace Client.Common.Services.AssetLoader
{
    public interface IAssetReceiver<in T> : IAssetReceiver
    {
        //Dont rename, this method used in reflection! 
        void Receive(T asset);
    }
}