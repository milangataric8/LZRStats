using AutoMapper;
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
    public class SeasonsController : ControllerBase
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SeasonsController> _logger;

        public SeasonsController(ISeasonRepository seasonRepository, IMapper mapper, ILogger<SeasonsController> logger)
        {
            _seasonRepository = seasonRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<SeasonResponse>> GetAll()
        {
            var seasons = await _seasonRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<SeasonResponse>>(seasons);

            return result;
        }
    }
}
