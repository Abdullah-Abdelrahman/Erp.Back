using Microsoft.AspNetCore.Http;

namespace Name.Service.Abstracts
{
    public interface IFileService
    {

        public Task<string> UploadFile(IFormFile? file, string WebRootPath);

        public Task<byte[]> GetFileAsync(string fileName);

    }
}
