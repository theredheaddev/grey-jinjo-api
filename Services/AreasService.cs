using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banjo_kazooie_api.Helpers;
using Banjo_kazooie_api.Models;
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

        public async Task<List<Area>> GetAreas()
        {
            var content = await RepositoryParser.ParseRepository<List<Area>>(filePaths.Areas);
            return content;
        }

        public async Task<Area> GetById(int id)
        {
            var areas = await GetAreas();
            
            var item = areas.First(x => x.Id == id);

            return item;
        }
    }
}