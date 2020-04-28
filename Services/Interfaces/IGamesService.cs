using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;

namespace Banjo_kazooie_api.Services.Interfaces
{
    public interface IGamesService
    {
        Task<List<Game>> GetGames();
        Task<Game> GetById(int id);
    }
}