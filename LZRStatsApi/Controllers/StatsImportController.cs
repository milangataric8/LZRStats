using LZRStatsApi.Helpers;
using LZRStatsApi.Importers;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Enums;
using LZRStatsApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly IFileConverterService _fileConverter;
        private readonly string tempFileName = "temp.docx";
        public StatsImportController(
            IStatsImporter statsImporter,
            IGameService gameService,
            ILogger<StatsImportController> logger,
            IFileImportHistoryService fileImportHistoryService,
            IFileConverterService fileConverter)
        {
            _statsImporter = statsImporter;
            _gameService = gameService;
            _logger = logger;
            _fileImportHistoryService = fileImportHistoryService;
            _fileConverter = fileConverter;
        }



        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Import([FromForm]FilesImportSettings importSettings)
        {
            string fullPath = string.Empty;
            string wordFilePath = string.Empty;
            var filesSkipped = new List<string>();
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
                        filesSkipped.Add(file.FileName);
                        continue;
                    }
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var matchData = fileName.ReplaceBadMinusCharacter().Split('-');
                    int roundNumber = int.Parse(matchData[0]);
                    int matchNumber = int.Parse(matchData[1]);
                    string teamName = matchData[2].Split('.')[0];
                    var gameImported = await _gameService.IsGameImported(roundNumber, matchNumber, teamName);
                    if (gameImported)
                    {
                        _logger.LogWarning($"File already imported. {file.FileName}");
                        filesSkipped.Add(fileName);
                        continue;
                    }

                    fullPath = Path.Combine(pathToSave, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    wordFilePath = Path.Combine(pathToSave, tempFileName); //TODO import from pdf directly without converting
                    _fileConverter.ConvertPdfToDocx(fullPath, wordFilePath);
                    GameDetails gameDetails = new GameDetails
                    {
                        FileName = fileName,
                        FilePath = wordFilePath,
                        League = importSettings.League,
                        SeasonId = importSettings.SeasonId,
                        GameType = (GameTypeEnum)Enum.Parse(typeof(GameTypeEnum), importSettings.GameType)
                    };

                    await _statsImporter.ImportAsync(gameDetails);
                    await _fileImportHistoryService.AddOrUpdateAsync(new FileImportHistory { FileName = fileName, DateImported = DateTime.Now });
                }

                return Ok(filesSkipped);
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