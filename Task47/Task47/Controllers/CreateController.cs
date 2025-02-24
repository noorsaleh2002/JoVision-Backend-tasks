using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Task47.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private readonly string _fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
        [HttpPost("create")]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromForm] string owner)
        {
            if (file == null || file.Length == 0 || string.IsNullOrEmpty(owner))
            {
                return BadRequest("File or Owner is missing.");
            }
            try
            {
                var filePath = Path.Combine(_fileDirectory, file.FileName);
                if (System.IO.File.Exists(filePath))
                {
                    return BadRequest("File with the same name already exists.");
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);//saving the image
                }
                //create metadata for the image
                var fileMetadata = new
                {
                    Owner = owner,
                    CreationTime = DateTime.Now,
                    LastModifiedTime = DateTime.Now

                };
                //saving metadata as JSON
                var jsonMetaDataPath = Path.Combine(_fileDirectory, $"{Path.GetFileNameWithoutExtension(file.FileName)}.json");
                System.IO.File.WriteAllText(jsonMetaDataPath, JsonConvert.SerializeObject(fileMetadata));
                return Created($"api/file/{file.FileName}", new { message = "File uploaded successfully." });

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


    }
}
