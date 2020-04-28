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
    public class EnemiesService : IEnemiesService
    {
        private readonly FilePaths filePaths;
        public EnemiesService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<Enemy>> GetEnemies(EnemyQuery query)
        {
            var content = await RepositoryParser.ParseRepository<List<Enemy>>(filePaths.Enemies);

            var queryedItems = FilterEnemies(content, query);

            return queryedItems;
        }

        public async Task<Enemy> GetById(int id)
        {
            var enemies = await GetEnemies(null);

            var item = enemies.First(x => x.Id == id);

            return item;
        }

        private List<Enemy> FilterEnemies(List<Enemy> enemies, EnemyQuery query)
        {
            if (query == null) return enemies;

            if (query.Id != null)
            {
                enemies = enemies.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Name != null)
            {
                enemies = enemies.Where(x =>
                    query.Name.Any(y =>
                        x.Name.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.GameId != null)
            {
                enemies = enemies.Where(x =>
                    query.GameId.Any(id =>
                        x.AppearsInGame.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            if (query.LevelId != null)
            {
                enemies = enemies.Where(x =>
                    query.GameId.Any(id =>
                        x.AppearsInLevel.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            return enemies;
        }
    }
}