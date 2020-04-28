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
    public class EnemiesController: ControllerBase
    {
        private readonly IEnemiesService enemiesService;
        public EnemiesController(IEnemiesService enemiesService)
        {
            this.enemiesService = enemiesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEnemies([FromQuery] EnemyQuery query)
        {
            try
            {
                return Ok(await enemiesService.GetEnemies(query));
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
                return Ok(await enemiesService.GetById(id));
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