using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Banjo_kazooie_api.Services.Interfaces;

namespace Banjo_kazooie_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AreasController: ControllerBase
    {
        private readonly IAreasService areasService;
        public AreasController(IAreasService areasService)
        {
            this.areasService = areasService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAreas()
        {
            try
            {
                return Ok(await areasService.GetAreas());
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