using System;
using System.Threading.Tasks;
using Banjo_kazooie_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banjo_kazooie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController: ControllerBase
    {
        private readonly IGamesService gamesService;
        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                return Ok(this.gamesService.GetGames());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}