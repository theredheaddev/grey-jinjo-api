using System;
using System.IO;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models.QueryObjects;
using Banjo_kazooie_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banjo_kazooie_api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController: ControllerBase
    {
        private readonly ICharactersService charactersService;
        public CharactersController(ICharactersService charactersService)
        {
            this.charactersService = charactersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CharacterQuery query)
        {
            try
            {
                return Ok(await charactersService.GetCharacters(query));
            }
            catch(FileNotFoundException fileNotFoundEx)
            {
                return BadRequest(fileNotFoundEx);
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
                return Ok(await charactersService.GetById(id));
            }
            catch(FileNotFoundException fileNotFoundEx)
            {
                return BadRequest(fileNotFoundEx);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}