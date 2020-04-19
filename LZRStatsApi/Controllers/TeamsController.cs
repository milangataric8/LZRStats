using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LZRStatsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TeamsController> _logger;
        public TeamsController(ITeamRepository teamRepository, IMapper mapper, ILogger<TeamsController> logger)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<TeamResponse> GetAll()
        {
            IEnumerable<Team> teams = _teamRepository.GetAll();
            var result = _mapper.Map<IEnumerable<TeamResponse>>(teams);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var team = await _teamRepository.GetSingleByAsync(x => x.Id == id);
                await _teamRepository.DeleteAsync(team);
                await _teamRepository.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Delete failed for team {id}");
                return BadRequest("Error occured");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Team team)
        {
            try
            {
                await _teamRepository.AddOrUpdateAsync(team);
                await _teamRepository.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Create failed for team {team.Name}");
                return BadRequest("Error occured");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Team team)
        {
            try
            {
                await _teamRepository.UpdateAsync(team);
                await _teamRepository.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Update failed for team {id}");
                return BadRequest("Error occured");
            }
        }
    }
}
