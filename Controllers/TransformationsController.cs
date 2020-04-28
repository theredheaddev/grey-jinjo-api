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
    public class TransformationsController: ControllerBase
    {
        private readonly ITransformationsService transformationsService;
        public TransformationsController(ITransformationsService transformationsService)
        {
            this.transformationsService = transformationsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransformations([FromQuery] TransformationQuery query)
        {
            try
            {
                return Ok(await transformationsService.GetTransformations(query));
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
                return Ok(await transformationsService.GetById(id));
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