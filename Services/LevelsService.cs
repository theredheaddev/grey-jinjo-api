using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Helpers;
using Banjo_kazooie_api.Models;
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

        public async Task<List<Level>> GetLevels()
        {
            var content = await RepositoryParser.ParseRepository<List<Level>>(filePaths.Levels);
            return content;
        }
    }
}