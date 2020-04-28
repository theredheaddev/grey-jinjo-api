using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Banjo_kazooie_api.Helpers;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Banjo_kazooie_api.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly FilePaths filePaths;
        public CharactersService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<Character>> GetCharacters()
        {
            var contents = await RepositoryParser.ParseRepository<List<Character>>(filePaths.Characters);
            return contents;
        }

        public async Task<Character> GetById(int id)
        {
            var characters = await GetCharacters();

            var item = characters.First(x => x.Id == id);

            return item;
        }
    }
}