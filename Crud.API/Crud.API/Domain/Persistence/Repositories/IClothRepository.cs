using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;

namespace Crud.API.Domain.Persistence.Repositories
{
    public interface IClothRepository
    {
        Task<IEnumerable<Cloth>> ListAsync();
        Task<Cloth> FindById(int id);
        Task AddAsync(Cloth cloth);
        void Update(Cloth cloth);
        void Remove(Cloth cloth);
    }
}