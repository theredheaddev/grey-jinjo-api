using System;
using System.IO;
using System.Threading.Tasks;
using Banjo_kazooie_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banjo_kazooie_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TransformationsController: ControllerBase
    {
        private readonly ITransformationsService transformationsService;
        public TransformationsController(ITransformationsService transformationsService)
        {
            this.transformationsService = transformationsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransformations()
        {
            try
            {
                return Ok(await transformationsService.GetTransformations());
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