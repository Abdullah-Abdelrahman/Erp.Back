using Microsoft.AspNetCore.Http;
using Name.Service.Abstracts;
//these 2 libarariys are for working with an file 

namespace Name.Service.Implementations
{
  public class FileService : IFileService
  {
    private readonly HttpClient _httpClient;

    public FileService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }
    public async Task<byte[]> GetFileAsync(string? fileName)
    {
      if (fileName == null)
      {
        return null;
      }
      var response = await _httpClient.GetAsync($"api/File/{fileName}");
      if (response.IsSuccessStatusCode)
      {
        return await response.Content.ReadAsByteArrayAsync();
      }

      // Optionally, handle errors based on status codes
      // throw new HttpRequestException("File could not be retrieved.");
      return null;
    }

    //Create an file for the image and creat an uniqe name for it
    public async Task<string> UploadFile(IFormFile? file, string WebRootPath)
    {
      string uniqueFileName = null;

      if (file != null)
      {
        string uploadsFolder = Path.Combine(WebRootPath, "Files");
        uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
          file.CopyTo(fileStream);
        }
      }
      return uniqueFileName;
    }
  }
}
