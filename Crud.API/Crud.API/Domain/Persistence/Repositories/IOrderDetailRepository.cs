using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;

namespace Crud.API.Domain.Persistence.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> ListByOrderIdAsync(int orderId);
        Task<OrderDetail> FindByOrderIdAndClothId(int orderId, int clothId);
        Task AddAsync(OrderDetail orderDetail);
        void Remove(OrderDetail orderDetail);
    }
}