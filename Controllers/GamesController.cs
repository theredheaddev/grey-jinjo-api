using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Banjo_kazooie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController: ControllerBase
    {
        public GamesController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}