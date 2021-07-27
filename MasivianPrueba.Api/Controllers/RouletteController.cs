using MasivianPrueba.Core.Contanst;
using MasivianPrueba.Core.Dto;
using MasivianPrueba.Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasivianPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : Controller
    {
        private readonly IRouletteService _rouletteService;
        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }
        [HttpPost("CreateRoulette")]
        public IActionResult CreateRoulette()
        {
            return Ok( _rouletteService.CreateRoulette());
        }
        [HttpPatch("OpenRoulette")]
        [ApiConventionMethod(typeof(DefaultApiConventions),nameof(DefaultApiConventions.Update))]
        public async Task<IActionResult> OpenRoulette(int id)
        {
            return Ok(await _rouletteService.OpenRoulette(id));
        }
        [HttpPost("BetRoulette")]
        public IActionResult OpenRoulette([FromHeader] string idUser,BetDto betDtp)
        {
            return Ok(_rouletteService.BetRoulettte(idUser,betDtp));
        }
        [HttpPost("CloseRoulette")]
        public IActionResult CloseRoulette(int idRoulette)
        {
            return Ok( _rouletteService.CloseRoulette(idRoulette));
        }

    }
}
