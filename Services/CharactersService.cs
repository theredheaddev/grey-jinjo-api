using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Banjo_kazooie_api.Helpers;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Models.QueryObjects;
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

        public async Task<List<Character>> GetCharacters(CharacterQuery query)
        {
            var contents = await RepositoryParser.ParseRepository<List<Character>>(filePaths.Characters);

            var queryedItems = FilterCharacters(contents, query);

            return queryedItems;
        }

        public async Task<Character> GetById(int id)
        {
            var characters = await GetCharacters(null);

            var item = characters.First(x => x.Id == id);

            return item;
        }

        private List<Character> FilterCharacters(List<Character> characters, CharacterQuery query)
        {
            if (query == null) return characters;

            if (query.Id != null)
            {
                characters = characters.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Name != null)
            {
                characters = characters.Where(x =>
                    query.Name.Any(y =>
                        x.Name.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.GameId != null)
            {
                characters = characters.Where(x =>
                    query.GameId.Any(id =>
                        x.AppearsInGame.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            if (query.IsMainCharacter != null)
            {
                characters = characters.Where(x => x.IsMainCharacter == query.IsMainCharacter).ToList();
            }

            return characters;
        }
    }
}