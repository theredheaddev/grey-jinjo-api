using System;
using System.IO;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models.QueryObjects;
using Banjo_kazooie_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banjo_kazooie_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MiniGamesController : ControllerBase
    {
        private readonly IMiniGamesService miniGamesService;
        public MiniGamesController(IMiniGamesService miniGamesService)
        {
            this.miniGamesService = miniGamesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMiniGames([FromQuery] MiniGameQuery query)
        {
            try
            {
                return Ok(await miniGamesService.GetMiniGames(query));
            }
            catch (FileNotFoundException ex)
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
                return Ok(await miniGamesService.GetByIdAsync(id));
            }
            catch (FileNotFoundException ex)
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