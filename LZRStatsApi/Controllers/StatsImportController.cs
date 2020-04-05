using LZRStatsApi.Attributes;
using LZRStatsApi.Helpers;
using LZRStatsApi.Importers;
using LZRStatsApi.Services;
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
        private readonly IGameService _gameService;
        private readonly string tempFileName = "temp.docx";
        public StatsImportController(IStatsImporter statsImporter, IGameService gameService)
        {
            _statsImporter = statsImporter;
            _gameService = gameService;
        }

        [HttpPost, DisableRequestSizeLimit]
        //[ServiceFilter(typeof(ValidateFileAttribute))]
        public async Task<IActionResult> Import()
        {
            string fullPath = string.Empty;
            string wordFilePath = string.Empty;
            try
            {
                var folderName = Path.Combine("Resources", "Files", "PDF");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);
                foreach (var file in Request.Form.Files)
                {
                    if (file.Length <= 0) continue; // TODO - log for which file!! Add isFileUploaded check
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var matchData = fileName.ReplaceBadMinusCharacter().Split('-');
                    var gameImported = await _gameService.IsGameImported(int.Parse(matchData[0]), int.Parse(matchData[1]), matchData[2].Split('.')[0]);
                    if (gameImported) continue;

                    fullPath = Path.Combine(pathToSave, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    wordFilePath = Path.Combine(pathToSave, tempFileName);
                    FileConverter.ConvertPdfToDocx(fullPath, wordFilePath);

                    //TODO db access rework
                    await _statsImporter.ExtractFromFile(wordFilePath, fileName);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                // TODO log error
                return BadRequest("Import failed.");
            }
            finally
            {
                if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);
                if (System.IO.File.Exists(wordFilePath)) System.IO.File.Delete(wordFilePath);
            }
        }
    }
}