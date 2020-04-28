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

            var queryedItems = FilterAbilites(content, query);

            return queryedItems;
        }

        public async Task<Ability> GetById(int id)
        {
            var abilities = await GetAbilities(null);

            var item = abilities.First(x => x.Id == id);

            return item;
        }

        private List<Ability> FilterAbilites(List<Ability> abilities, AbilityQuery query)
        {
            if (query == null) return abilities;

            if (query.Id != null)
            {
                abilities = abilities.Where(x => query.Id.IndexOf(x.Id) >= 0).ToList();
            }

            if (query.Name != null)
            {
                abilities = abilities.Where(x => 
                    query.Name.Where(y => 
                        x.Name.ToLower()
                            .Contains(y.ToLower()
                        )
                    ).Count() > 0)
                .ToList();
            }

            return abilities;
        }
    }
}