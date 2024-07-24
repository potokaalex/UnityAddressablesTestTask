using Client.Common.Data.Progress;

namespace Client.Common.Services.ProgressService.Loader
{
    public interface IProgressReader
    {
        void OnLoad(ProgressData progress);
    }
}