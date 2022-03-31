using System.Threading.Tasks;
using Crud.API.Domain.Persistence.Contexts;
using Crud.API.Domain.Persistence.Repositories;

namespace Crud.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}