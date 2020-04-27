using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Banjo_kazooie_api.Services.Interfaces;

namespace Banjo_kazooie_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CollectablesControler: ControllerBase
    {
        private readonly ICollectablesService collectablesService;
        public CollectablesControler(ICollectablesService collectablesService)
        {
            this.collectablesService = collectablesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCollectables()
        {
            try
            {
                return Ok(await collectablesService.GetCollectables());
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