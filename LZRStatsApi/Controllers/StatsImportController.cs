using LZRStatsApi.Helpers;
using LZRStatsApi.Importers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LZRStatsApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class StatsImportController : ControllerBase
    {
        private readonly IStatsImporter _statsImporter;
        private readonly string tempFileName = "temp.docx";
        public StatsImportController(IStatsImporter statsImporter)
        {
            _statsImporter = statsImporter;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Import()
        {
            string fullPath = string.Empty;
            string wordFilePath = string.Empty;
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Files", "PDF");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);

                if (file.Length <= 0) return BadRequest("Invalid file content!");

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                wordFilePath = Path.Combine(pathToSave, tempFileName);
                FileConverter.ConvertPdfToDocx(fullPath, wordFilePath);

                //TODO db access rework
                //await _statsImporter.ExtractFromFile(wordFilePath, fileName);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);
                if (System.IO.File.Exists(wordFilePath)) System.IO.File.Delete(wordFilePath);
            }
        }
    }
}