using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Banjo_kazooie_api.Services.Interfaces;
using Banjo_kazooie_api.Models.QueryObjects;

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
        public async Task<IActionResult> GetAreas([FromQuery] AreaQuery query)
        {
            try
            {
                return Ok(await areasService.GetAreas(query));
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await areasService.GetById(id));
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