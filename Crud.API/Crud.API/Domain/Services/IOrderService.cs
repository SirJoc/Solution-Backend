using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Services.Communication;

namespace Crud.API.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListAsync();
        Task<IEnumerable<Order>> ListByClothIdAsync(int clothId);
        Task<OrderResponse> GetByIdAsync(int id);
        Task<OrderResponse> SaveAsync(int clothId, Order order);
        Task<OrderResponse> UpdateAsync(int id, Order order);
        Task<OrderResponse> DeleteAsync(int id);
    }
}