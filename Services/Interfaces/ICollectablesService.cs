using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Models.QueryObjects;

namespace Banjo_kazooie_api.Services.Interfaces
{
    public interface ICollectablesService
    {
        Task<List<Collectable>> GetCollectables(CollectableQuery query);
        Task<Collectable> GetById(int id);
    }
}