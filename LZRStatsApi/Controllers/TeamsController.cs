using System.Collections.Generic;
using System.Threading.Tasks;
using LZRStatsApi.Models;
using LZRStatsApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LZRStatsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[teams]")]
    public class TeamsController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _teamService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var e = _teamService.GetById(id);
            if (e == null)
            {
                return NotFound();
            }
            return new ObjectResult(e);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Team team)
        {

            if(team == null) 
            {
                return BadRequest();
            }
            _teamService.Create(team);
            return CreatedAtRoute(new { Controller = "Teams", id = team.Id }, team);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Team team)
        {
            if (team == null)
            {
                return BadRequest();
            }
            var project = _teamService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            _teamService.Update(team);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamService.Delete(id);
            return Ok(id);
        }
    }
}
