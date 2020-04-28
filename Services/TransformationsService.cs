using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banjo_kazooie_api.Helpers;
using Banjo_kazooie_api.Models;
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

        public async Task<List<Transformation>> GetTransformations()
        {
            var content = await RepositoryParser.ParseRepository<List<Transformation>>(filePaths.Transformations);
            return content;
        }

        public async Task<Transformation> GetById(int id)
        {
            var transformations = await GetTransformations();
        
            var item = transformations.First(x => x.Id == id);

            return item;
        }
    }
}