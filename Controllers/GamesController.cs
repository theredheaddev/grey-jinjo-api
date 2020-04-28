using System;
using System.IO;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models.QueryObjects;
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
        public async Task<IActionResult> GetGames([FromQuery] GameQuery query)
        {
            try
            {
                return Ok(await this.gamesService.GetGames(query));
            }
            catch(FileNotFoundException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await this.gamesService.GetById(id));
            }
            catch(FileNotFoundException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}