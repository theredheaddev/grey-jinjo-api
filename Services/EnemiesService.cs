using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Helpers;
using Banjo_kazooie_api.Models;
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

        public async Task<List<Enemy>> GetEnemies()
        {
            var content = await RepositoryParser.ParseRepository<List<Enemy>>(filePaths.Enemies);
            return content;
        }
    }
}