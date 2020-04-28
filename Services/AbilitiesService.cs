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
    public class AbilitiesService : IAbilitiesService
    {
        private readonly FilePaths filePaths;
        public AbilitiesService(IOptions<FilePaths> filePaths)
        {
            this.filePaths = filePaths.Value;
        }

        public async Task<List<Ability>> GetAbilities(AbilityQuery query)
        {
            var content = await RepositoryParser.ParseRepository<List<Ability>>(filePaths.Abilities);

            return content;
        }

        public async Task<Ability> GetById(int id)
        {
            var abilities = await GetAbilities(null);

            var item = abilities.First(x => x.Id == id);
            
            return item;
        }
    }
}