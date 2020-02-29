using AutoMapper;
using LZRStatsApi.Models;
using LZRStatsApi.Models.Responses;
using LZRStatsApi.Repositories;
using LZRStatsApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public PlayersController(IPlayerRepository playerRepo, IMapper mapper)
        {
            _playerRepo = playerRepo;
            _mapper = mapper;
        }


        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<PlayerResponse> GetAll()
        {
            return _playerRepo.GetAll();
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
            return new ObjectResult(p);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Player item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _playerRepo.Add(item);
            return CreatedAtRoute((Controller: "Player", id: item.Id), item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Player item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var project = _playerRepo.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            _playerRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _playerRepo.Remove(id);
            return Ok(id);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetAll()
        //{
        //    var players = await _playerRepo.GetAllAsync();

        //    //TODO return view model
        //    //var result = _mapper.Map<PlayerViewModel>(players);
        //    return Ok(players);
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlayer([FromRoute] int id, [FromBody] Player player)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != player.Id)
        //    {
        //        return BadRequest();
        //    }


        //    try
        //    {
        //        var entity = _mapper.Map<Player>(player);
        //        await _playerRepo.UpdateAsync(entity);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //    return NoContent();
        //}

        //// POST: api/Workouts
        //[HttpPost]
        //public async Task<IActionResult> PostPlayer([FromBody] PlayerViewModel player)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var newPlayer = _mapper.Map<Player>(player);
        //    await _playerRepo.CreateAsync(newPlayer);
        //    await _playerRepo.SaveChangesAsync();

        //    return Ok();
        //}

        //// DELETE: api/Workouts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var players = await _playerRepo.GetByAsync(x => x.Id == id);
        //    if (players == null)
        //    {
        //        return NotFound();
        //    }

        //    await _playerRepo.DeleteAsync(players.SingleOrDefault());
        //    await _playerRepo.SaveChangesAsync();

        //    return Ok(players);
        //}
    }

}