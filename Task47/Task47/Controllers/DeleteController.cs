using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;

namespace   Task47.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        
        private readonly string _fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

        
        [HttpGet("delete")]
        public IActionResult DeleteFile([FromQuery] string fileName, [FromQuery] string fileOwner)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(fileOwner))
            {
                return BadRequest("File name or owner missing.");
            }

            try
            {
                
                var filePath = Path.Combine(_fileDirectory, fileName);
                var jsonMetadataPath = Path.Combine(_fileDirectory, $"{Path.GetFileNameWithoutExtension(fileName)}.json");

                
                if (!System.IO.File.Exists(filePath) || !System.IO.File.Exists(jsonMetadataPath))
                {
                    return BadRequest("File or metadata does not exist.");
                }

                
                var metadataContent = System.IO.File.ReadAllText(jsonMetadataPath);
                dynamic metadata = JsonConvert.DeserializeObject(metadataContent);

               
                if (metadata.Owner != fileOwner)
                {
                    return Forbid("Owner name does not match.");
                }

                
                System.IO.File.Delete(filePath);
                System.IO.File.Delete(jsonMetadataPath);

                return Ok(new { message = "File and metadata deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
