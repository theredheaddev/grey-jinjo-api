using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banjo_kazooie_api.Helpers;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Models.QueryObjects;
using Banjo_kazooie_api.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Banjo_kazooie_api.Services
{
    public class MiniGamesService : IMiniGamesService
    {
        private readonly FilePaths filePaths;
        public MiniGamesService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<MiniGame>> GetMiniGames(MiniGameQuery query)
        {
            var content = await RepositoryParser.ParseRepository<List<MiniGame>>(filePaths.MiniGames);

            var queryedItems = FilterMiniGames(content, query);

            return queryedItems;
        }

        public async Task<MiniGame> GetByIdAsync(int id)
        {

            var miniGames = await GetMiniGames(null);

            var item = miniGames.First(x => x.Id == id);

            return item;
        }

        private List<MiniGame> FilterMiniGames(List<MiniGame> miniGames, MiniGameQuery query)
        {
            if (query == null) return miniGames;

            if (query.Id != null)
            {
                miniGames = miniGames.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Description != null)
            {
                miniGames = miniGames.Where(x =>
                    query.Description.Any(y =>
                        x.Description.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.Rules != null)
            {
                miniGames = miniGames.Where(x =>
                    query.Rules.Any(y =>
                        x.Rules.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.LevelId != null)
            {
                miniGames = miniGames.Where(x =>
                    query.LevelId.Any(id => x.AppearsInLevel.Contains(id.ToString()))
                ).ToList();
            }

            if (query.GameId != null)
            {
                miniGames = miniGames.Where(x =>
                    query.GameId.Any(id =>
                        x.AppearsInGame.Contains(id.ToString())
                    )
                ).ToList();
            }

            if (query.AreaId != null)
            {
                miniGames = miniGames.Where(x =>
                    query.AreaId.Any(y =>
                        x.Area.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            return miniGames;
        }
    }
}