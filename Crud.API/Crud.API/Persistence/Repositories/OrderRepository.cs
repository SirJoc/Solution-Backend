using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Persistence.Contexts;
using Crud.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Persistence.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> FindById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _context.Orders
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> ListByClothIdAsync(int clothId)
        {
            return await _context.Orders
                .Where(c => c.ClothId == clothId)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }
    }
}