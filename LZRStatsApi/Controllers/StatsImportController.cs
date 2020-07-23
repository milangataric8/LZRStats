using LZRStatsApi.Helpers;
using LZRStatsApi.Importers;
using LZRStatsApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private readonly ILogger<StatsImportController> _logger;
        private readonly IFileImportHistoryService _fileImportHistoryService;
        private readonly string tempFileName = "temp.docx";
        public StatsImportController(IStatsImporter statsImporter, IGameService gameService, ILogger<StatsImportController> logger, IFileImportHistoryService fileImportHistoryService)
        {
            _statsImporter = statsImporter;
            _gameService = gameService;
            _logger = logger;
            _fileImportHistoryService = fileImportHistoryService;
        }



        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Import([FromForm]FileDetails fileDetails)
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
                    if (file.Length <= 0)
                    {
                        _logger.LogWarning($"File invalid. {file.FileName}");
                        continue;
                    }
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var matchData = fileName.ReplaceBadMinusCharacter().Split('-');
                    var gameImported = await _gameService.IsGameImported(int.Parse(matchData[0]), int.Parse(matchData[1]), matchData[2].Split('.')[0]);
                    if (gameImported)
                    {
                        _logger.LogWarning($"File already imported. {file.FileName}");
                        continue;
                    }

                    fullPath = Path.Combine(pathToSave, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    wordFilePath = Path.Combine(pathToSave, tempFileName);
                    FileConverter.ConvertPdfToDocx(fullPath, wordFilePath);
                    fileDetails.FileName = fileName;
                    fileDetails.FilePath = wordFilePath;
                    await _statsImporter.ExtractFromFile(fileDetails);
                    await _fileImportHistoryService.SaveFile(new Models.FileImportHistory { FileName = fileName, DateImported = DateTime.Now });
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "File import failed");
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