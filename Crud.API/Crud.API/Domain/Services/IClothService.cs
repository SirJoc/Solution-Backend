using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Services.Communication;

namespace Crud.API.Domain.Services
{
    public interface IClothService
    {
        Task<IEnumerable<Cloth>> ListAsync();
        Task<ClothResponse> GetByIdAsync(int id);
        Task<ClothResponse> SaveAsync(Cloth cloth);
        Task<ClothResponse> UpdateAsync(int id, Cloth cloth);
        Task<ClothResponse> DeleteAsync(int id);
    }
}