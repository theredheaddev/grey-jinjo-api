using System;
using System.IO;
using System.Threading.Tasks;
using Banjo_kazooie_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banjo_kazooie_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LevelsController: ControllerBase
    {
        private readonly ILevelsService levelsService;
        public LevelsController(ILevelsService levelsService)
        {
            this.levelsService = levelsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLevels()
        {
            try
            {
                return Ok(await levelsService.GetLevels());
            }
            catch(FileNotFoundException ex)
            {
                return BadRequest(ex);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}