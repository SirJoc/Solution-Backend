using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Persistence.Contexts;
using Crud.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Persistence.Repositories
{
    public class ClothRepository : BaseRepository, IClothRepository
    {
        public ClothRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Cloth>> ListAsync()
        {
            return await _context.Cloths.ToListAsync();
        }

        public async Task<Cloth> FindById(int id)
        {
            return await _context.Cloths.FindAsync(id);
        }

        public async Task AddAsync(Cloth cloth)
        {
            await _context.AddAsync(cloth);
        }

        public void Update(Cloth cloth)
        {
            _context.Cloths.Update(cloth);
        }

        public void Remove(Cloth cloth)
        {
            _context.Cloths.Remove(cloth);
        }
    }
}