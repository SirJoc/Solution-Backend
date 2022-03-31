using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Services;
using Crud.API.Domain.Services.Communication;

namespace Crud.API.Services
{
    public class OrderService : IOrderService
    {
        public Task<IEnumerable<Order>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Order>> ListByClothIdAsync(int clothId)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderResponse> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderResponse> SaveAsync(int clientId, Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderResponse> UpdateAsync(int id, Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderResponse> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}