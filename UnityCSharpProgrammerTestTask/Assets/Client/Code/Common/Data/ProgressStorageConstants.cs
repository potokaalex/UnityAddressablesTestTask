using System.IO;
using Client.Common.Data.Progress;
using UnityEngine;

namespace Client.Common.Data
{
    public static class ProgressStorageConstants
    {
        private const string FilesExtension = "data";
        
        public static readonly string DirectoryPath = Path.Combine(Application.dataPath, "Saves");
        public static readonly string FilePath =  Path.Combine(DirectoryPath, nameof(ProgressData));
        private static readonly string FileName = Path.ChangeExtension(nameof(ProgressData), FilesExtension);
    }
}