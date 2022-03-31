using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;

namespace Crud.API.Domain.Persistence.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> FindById(int id);
        Task<IEnumerable<Order>> ListAsync();
        Task<IEnumerable<Order>> ListByClothIdAsync(int clothId);
        Task AddAsync(Order order);
        void Update(Order order);
        void Remove(Order order);
    }
}