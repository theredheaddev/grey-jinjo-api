using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Services.Interfaces;

namespace Banjo_kazooie_api.Services
{
    public class GamesService : IGamesService
    {
        public async Task<List<Game>> GetGames()
        {
            return null;
        }
    }
}