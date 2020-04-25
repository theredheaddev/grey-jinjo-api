using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Services.Interfaces;
using Banjo_kazooie_api.Helpers;
using Microsoft.Extensions.Options;

namespace Banjo_kazooie_api.Services
{
    public class GamesService : IGamesService
    {
        private readonly FilePaths filePaths;
        public GamesService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<Game>> GetGames()
        {
            var content = await RepositoryParser.ParseRepository<List<Game>>(filePaths.Games);
            return content;
        }
    }
}