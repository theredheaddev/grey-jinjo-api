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
    public class LevelsService : ILevelsService
    {
        private readonly FilePaths filePaths;
        public LevelsService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<Level>> GetLevels(LevelQuery query)
        {
            var content = await RepositoryParser.ParseRepository<List<Level>>(filePaths.Levels);
            
            var queryedItems = FilterLevels(content, query);

            return queryedItems;
        }

        public async Task<Level> GetById(int id)
        {
            var levels = await GetLevels(null);

            var item = levels.First(x => x.Id == id);

            return item;
        }

         private List<Level> FilterLevels(List<Level> levels, LevelQuery query)
        {
            if (query == null) return levels;

            if (query.Id != null)
            {
                levels = levels.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Name != null)
            {
                levels = levels.Where(x =>
                    query.Name.Any(y =>
                        x.Name.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.GameId != null)
            {
                levels = levels.Where(x =>
                    query.GameId.Any(id =>
                        x.AppearsInGame.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            if (query.LevelId != null)
            {
                levels = levels.Where(x =>
                    query.LevelId.Any(id =>
                        x.Id == id
                    )
                ).ToList();
            }

            if (query.LevelNumber != null)
            {
                levels = levels.Where(x =>
                    query.LevelNumber.Any(id =>
                        x.LevelNumber == id
                    )
                ).ToList();
            }

            if (query.CharacterId != null)
            {
                levels = levels.Where(x =>
                    query.CharacterId.Any(id =>
                        x.Characters.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            if (query.CollectableId != null)
            {
                levels = levels.Where(x =>
                    query.CollectableId.Any(id =>
                        x.Collectables.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            if (query.LevelType != null)
            {
                levels = levels.Where(x =>
                    query.LevelType.Any(type => type == x.Type)
                ).ToList();
            }

            if (query.AbilityId != null)
            {
                levels = levels.Where(x =>
                    query.AbilityId.Any(id =>
                        x.AbilitiesLearned.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            if (query.TransformationId != null)
            {
                levels = levels.Where(x =>
                    query.TransformationId.Any(id =>
                        x.Transformations.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            return levels;
        }
    }
}