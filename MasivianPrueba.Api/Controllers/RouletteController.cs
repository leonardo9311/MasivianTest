using MasivianPrueba.Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasivianPrueba.Api.Controllers
{
    public class RouletteController : Controller
    {
        private readonly IRouletteService _rouletteService;
        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }
    }
}
