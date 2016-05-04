using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public enum FileUploadError
    {
        None,
        UnsupportedFileExtensions,
        LargeFile
    }

    public class FileUploadResult
    {
        public bool IsSuccess { get; set; }
        public string AbsolutePath { get; set; }
        public string OriginalFileName { get; set; }
        public FileUploadError Error { get; set; }

        public static FileUploadResult WithError(FileUploadError error, string absolutePath = null, string originalFilename = null)
        {
            return new FileUploadResult
            {
                Error = error,
                AbsolutePath = absolutePath,
                OriginalFileName = originalFilename,
                IsSuccess = false
            };
        }

        public static FileUploadResult Success(string absolutePath, string originalFilename)
        {
            return new FileUploadResult
            {
                Error = FileUploadError.None,
                AbsolutePath = absolutePath,
                OriginalFileName = originalFilename,
                IsSuccess = true
            };
        }
    }
}
