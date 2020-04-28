using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Models.QueryObjects;

namespace Banjo_kazooie_api.Services.Interfaces
{
    public interface IGamesService
    {
        Task<List<Game>> GetGames(GameQuery query);
        Task<Game> GetById(int id);
    }
}