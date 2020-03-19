using LZRStatsApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace LZRStatsApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class StatsImportController : ControllerBase
    {

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Import()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Files", "PDF");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    string wordFilePath = FileConverter.ConvertPdfToDocx(fullPath);
                    // TODO import data and clean
                    //System.IO.File.Delete(fullPath);
                    //System.IO.File.Delete(wordFilePath);

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}