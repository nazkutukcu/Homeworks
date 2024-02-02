using Microsoft.EntityFrameworkCore.Storage;

namespace Homework1.API.Models.UnitOfWorks
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
