using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CodeAgenda.DataAccess
{
    /// <summary>
    /// Implementation of <see cref="IUnitOfWork"/>.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            if (!context.Database.CanConnect())
                context.Database.Migrate();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
