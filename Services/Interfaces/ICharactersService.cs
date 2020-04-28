using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;

namespace Banjo_kazooie_api.Services.Interfaces
{
    public interface ICharactersService
    {
        Task<List<Character>> GetCharacters();
        Task<Character> GetById(int id);
    }
}