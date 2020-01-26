using System.Threading.Tasks;
using LZRStatsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LZRStatsApi.Services;
using System.Collections.Generic;
using LZRStatsApi.Repositories;

namespace LZRStatsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepo;

        public PlayersController(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerRepo.GetAllAsync();
            return Ok(players);
        }


    }

}