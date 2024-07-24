using Client.Common.Data.Progress;

namespace Client.Common.Services.ProgressService.Saver
{
    public interface IProgressWriter
    {
        void OnSave(ProgressData progress);
    }
}