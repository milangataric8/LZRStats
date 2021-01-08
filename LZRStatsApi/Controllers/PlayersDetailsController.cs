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
    public class PlayersDetailsController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<PlayersController> _logger;
        public PlayersDetailsController(IPlayerRepository playerRepo, IMapper mapper, ILogger<PlayersController> logger)
        {
            _playerRepo = playerRepo;
            _mapper = mapper;
            _logger = logger;
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