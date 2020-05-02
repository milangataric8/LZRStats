using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<PlayersController> _logger;
        public PlayersController(IPlayerRepository playerRepo, IMapper mapper, ILogger<PlayersController> logger)
        {
            _playerRepo = playerRepo;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<PlayerResponse> GetAll()
        {
            var result = _playerRepo.GetAll();
            var players = _mapper.Map<IEnumerable<PlayerResponse>>(result);

            return players;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Player item)
        {
            try
            {
                await _playerRepo.AddOrUpdateAsync(item);
                await _playerRepo.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Create failed for player {item.LastName}");
                return BadRequest("Error occured");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var player = await _playerRepo.GetSingleByAsync(x => x.Id == id);
                await _playerRepo.DeleteAsync(player);
                await _playerRepo.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Delete failed for player {id}");
                return BadRequest("Error occured");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Player player)
        {
            try
            {
                await _playerRepo.UpdateAsync(player);
                await _playerRepo.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Update failed for player {id}");
                return BadRequest("Error occured");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetPlayerById(int id)
        {
            var p = _playerRepo.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<PlayerResponse>(p);

            return Ok(result);
        }
    }

}