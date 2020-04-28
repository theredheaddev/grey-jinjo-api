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
    public class TransformationsService : ITransformationsService
    {
        private readonly FilePaths filePaths;
        public TransformationsService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<Transformation>> GetTransformations(TransformationQuery query)
        {
            var content = await RepositoryParser.ParseRepository<List<Transformation>>(filePaths.Transformations);

            var queryedItems = FilterTransformations(content, query);

            return queryedItems;
        }

        public async Task<Transformation> GetById(int id)
        {
            var transformations = await GetTransformations(null);

            var item = transformations.First(x => x.Id == id);

            return item;
        }

        private List<Transformation> FilterTransformations(List<Transformation> transformations, TransformationQuery query)
        {
            if (query == null) return transformations;

            if (query.Id != null)
            {
                transformations = transformations.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Name != null)
            {
                transformations = transformations.Where(x =>
                    query.Name.Any(y =>
                        x.Name.ToLower()
                            .Contains(y.ToLower()
                        )
                    )
                ).ToList();
            }

            if (query.GameId != null)
            {
                transformations = transformations.Where(x =>
                    query.GameId.Any(id =>
                        x.AppearsInGame.Contains(id.ToString())
                    )
                ).ToList();
            }

            if (query.LevelId != null)
            {
                transformations = transformations.Where(x =>
                    query.GameId.Any(id =>
                        x.AppearsInLevel.Contains(id.ToString())
                    )
                ).ToList();
            }

            return transformations;
        }
    }
}