using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechXplorers.ArgumentValidation;

namespace Service
{
    public interface IFileUploadHandler
    {
        Task<string> UploadAsync(HttpRequestMessage request);
    }

    public class FileUploadHandler : IFileUploadHandler
    {
        private readonly MultipartFileStreamProvider multipartFileStreamProvider;

        public FileUploadHandler(MultipartFileStreamProvider multipartFileStreamProvider)
        {
            this.multipartFileStreamProvider = multipartFileStreamProvider;
        }

        public async Task<string> UploadAsync(HttpRequestMessage request)
        {
            Check
                .That(() => request).IsNotNull()
                .AndThat(() => request.Content).IsNotNull();

            if (!request.Content.IsMimeMultipartContent())
                throw new ApplicationException("File/Content is not MIME Multipart");

            multipartFileStreamProvider.FileData?.Clear();

            var fileData =
                (await request.Content.ReadAsMultipartAsync(multipartFileStreamProvider)).FileData.FirstOrDefault();

            if (!System.IO.File.Exists(fileData.LocalFileName))
                throw new ApplicationException(
                    $"File Not Exists or Unreadable/Corrupted File Data Contents. Filepath attempted: {fileData.LocalFileName}");

            return fileData.LocalFileName;
        }
    }
}
