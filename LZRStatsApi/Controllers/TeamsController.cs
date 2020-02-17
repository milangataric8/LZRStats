using LZRStatsApi.Models;
using LZRStatsApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Team> teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            //await _teamRepository.DeleteAsync(team);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Team team)
        {

            return Ok();
        }
    }
}
