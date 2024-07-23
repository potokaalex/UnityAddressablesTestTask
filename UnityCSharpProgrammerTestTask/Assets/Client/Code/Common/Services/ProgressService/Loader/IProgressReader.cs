using Client.Common.Data;

namespace Client.Common.Services.ProgressService.Loader
{
    public interface IProgressReader
    {
        void OnLoad(ProgressData progress);
    }
}