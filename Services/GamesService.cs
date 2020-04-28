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
            
            var queryedItems = FilterGames(content, query);
            
            return queryedItems;
        }

        public async Task<Game> GetById(int id)
        {
            var games = await GetGames(null);

            var item = games.First(x => x.Id == id);

            return item;
        }

        private List<Game> FilterGames(List<Game> games, GameQuery query)
        {
            if (query == null) return games;

            if (query.Id != null)
            {
                games = games.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Name != null)
            {
                games = games.Where(x =>
                    query.Name.Any(y =>
                        x.Name.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.Platform != null)
            {
                games = games.Where(x =>
                    query.Platform.ToLower().Contains(x.Platform.ToLower())
                ).ToList();
            }

            if (query.Released != null)
            {
                games = games.Where(x => query.Released == x.Released).ToList();
            }

            if (query.GameId != null)
            {
                games = games.Where(x =>
                    query.GameId.Any(id =>
                        x.Id == id
                    )
                ).ToList();
            }

            if (query.LevelId != null)
            {
                games = games.Where(x =>
                    query.LevelId.Any(id =>
                        x.Levels.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            if (query.CharacterId != null)
            {
                games = games.Where(x =>
                    query.CharacterId.Any(id =>
                        x.Characters.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            if (query.CollectableId != null)
            {
                games = games.Where(x =>
                    query.CollectableId.Any(id =>
                        x.Collectables.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            return games;
        }
    }
}