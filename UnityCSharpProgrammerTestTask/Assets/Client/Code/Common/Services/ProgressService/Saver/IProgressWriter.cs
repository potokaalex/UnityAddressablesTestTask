using Client.Common.Data;

namespace Client.Common.Services.ProgressService.Saver
{
    public interface IProgressWriter
    {
        void OnSave(ProgressData progress);
    }
}