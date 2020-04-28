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
    public class CollectablesService : ICollectablesService
    {
        private readonly FilePaths filePaths;
        public CollectablesService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }
        public async Task<List<Collectable>> GetCollectables(CollectableQuery query)
        {
            var content = await RepositoryParser.ParseRepository<List<Collectable>>(filePaths.Collectables);

            var queryedItems = FilterCollectables(content, query);

            return content;
        }

        public async Task<Collectable> GetById(int id)
        {
            var collectables = await GetCollectables(null);

            var item = collectables.First(x => x.Id == id);

            return item;
        }

        private List<Collectable> FilterCollectables(List<Collectable> collectables, CollectableQuery query)
        {
            if (query == null) return collectables;

            if (query.Id != null)
            {
                collectables = collectables.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Name != null)
            {
                collectables = collectables.Where(x =>
                    query.Name.Any(y =>
                        x.Name.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.GameId != null)
            {
                collectables = collectables.Where(x =>
                    query.GameId.Any(id =>
                        x.GameQuantity.Any(
                            y => y.Game.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }


            return collectables;
        }
    }
}