using System.Collections.Generic;
using System.Linq;
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

        public async Task<Enemy> GetById(int id)
        {
            var enemies = await GetEnemies();

            var item = enemies.First(x => x.Id == id);

            return item;
        }
    }
}