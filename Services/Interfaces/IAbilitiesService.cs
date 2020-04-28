using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Models.QueryObjects;

namespace Banjo_kazooie_api.Services.Interfaces
{
    public interface IAbilitiesService
    {
        Task<List<Ability>> GetAbilities(AbilityQuery query);
        Task<Ability> GetById(int id);
    }
}