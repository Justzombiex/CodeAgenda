using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
