using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;

namespace Banjo_kazooie_api.Services.Interfaces
{
    public interface IEnemiesService
    {
        Task<List<Enemy>> GetEnemies();
        Task<Enemy> GetById(int id);
    }
}