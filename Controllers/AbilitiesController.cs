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
    public class AbilitiesController: ControllerBase
    {
        private readonly IAbilitiesService abilitiesService;
        public AbilitiesController(IAbilitiesService abilitiesService)
        {
            this.abilitiesService = abilitiesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAbilities([FromQuery] AbilityQuery query)
        {
            try
            {
                return Ok(await abilitiesService.GetAbilities(query));
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
                return Ok(await abilitiesService.GetById(id));
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