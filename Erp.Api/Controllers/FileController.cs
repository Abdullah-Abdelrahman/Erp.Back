using Microsoft.AspNetCore.Mvc;

namespace Name.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var filePath = Path.Combine("Files", fileName); // Adjust path if needed
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var mimeType = "application/octet-stream"; // Change MIME type if known
            return File(fileBytes, mimeType, fileName);
        }
    }
}
