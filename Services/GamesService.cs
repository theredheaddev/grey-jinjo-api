using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Services.Interfaces;
using Banjo_kazooie_api.Helpers;
using Microsoft.Extensions.Options;
using System.Linq;
using Banjo_kazooie_api.Models.QueryObjects;

namespace Banjo_kazooie_api.Services
{
    public class GamesService : IGamesService
    {
        private readonly FilePaths filePaths;
        public GamesService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<Game>> GetGames(GameQuery query)
        {
            var content = await RepositoryParser.ParseRepository<List<Game>>(filePaths.Games);
            return content;
        }

        public async Task<Game> GetById(int id)
        {
            var games = await GetGames(null);

            var item = games.First(x => x.Id == id);

            return item;
        }
    }
}