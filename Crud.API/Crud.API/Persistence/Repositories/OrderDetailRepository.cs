using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Persistence.Contexts;
using Crud.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Persistence.Repositories
{
    public class OrderDetailRepository : BaseRepository, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<OrderDetail>> ListByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails
                .Where(p => p.OrderId == orderId)
                .Include(p => p.Order)
                .Include(p => p.Cloth)
                .ToListAsync();
        }

        public async Task<OrderDetail> FindByOrderIdAndClothId(int orderId, int clothId)
        {
            IEnumerable<OrderDetail> orderDetails = await _context.OrderDetails.Where(p => p.OrderId == orderId && p.ClothId == clothId)
                .ToListAsync();
            return orderDetails.Any() ? orderDetails.First() : null;
        }

        public async Task AddAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
        }

        public void Remove(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
        }
    }
}