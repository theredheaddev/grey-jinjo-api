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
    public class AreasService : IAreasService
    {
        private readonly FilePaths filePaths;
        public AreasService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<Area>> GetAreas(AreaQuery query)
        {
            var content = await RepositoryParser.ParseRepository<List<Area>>(filePaths.Areas);

            var queryedItems = FilterAreas(content, query);

            return queryedItems;
        }

        public async Task<Area> GetById(int id)
        {
            var areas = await GetAreas(null);

            var item = areas.First(x => x.Id == id);

            return item;
        }

        private List<Area> FilterAreas(List<Area> areas, AreaQuery query)
        {
            if (query == null) return areas;

            if (query.Id != null)
            {
                areas = areas.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Name != null)
            {
                areas = areas.Where(x =>
                    query.Name.Any(y =>
                        x.Name.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.GameId != null)
            {
                areas = areas.Where(x =>
                    query.GameId.Any(id =>
                        x.AppearsInGame.Any(
                            y => y.Contains(id.ToString())
                        )
                    )
                ).ToList();
            }

            return areas;
        }
    }
}