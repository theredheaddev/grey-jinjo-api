using System.Collections.Generic;
using System.Threading.Tasks;
using Banjo_kazooie_api.Models;

namespace Banjo_kazooie_api.Services.Interfaces
{
    public interface ITransformationsService
    {
        Task<List<Transformation>> GetTransformations();
        Task<Transformation> GetById(int id);
    }
}