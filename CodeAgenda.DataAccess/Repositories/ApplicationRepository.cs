using CodeAgenda.DataAccess.Abstract;
using CodeAgenda.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    /// <summary>
    /// Repository associated with the application entities.
    /// </summary>
    public partial class ApplicationRepository : IRepository
    {
        /// <summary>
        /// Cadena de conexión para generar la conexión a BD.
        /// </summary>
        protected string _connectionString;

        /// <summary>
        /// Contexto mediante el cual se establece la conexión a BD.
        /// </summary>
        protected ApplicationContext? _context;

        public bool IsInTransaction => _context is not null;

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión para la generar la conexión a BD.</param>
        public ApplicationRepository(string connectionString)
        {
            _connectionString = connectionString;
            _context = null;
        }

        public void BeginTransaction()
        {
            if (IsInTransaction)
                throw new InvalidOperationException("Cannot begin a new transaction before closing the current one.");
            // Creando nuevo contexto para la transacción.
            _context = new ApplicationContext(_connectionString);
            // Generando migración en caso de que la base de datos no exista.
            if (!_context.Database.CanConnect())
                _context.Database.Migrate();
        }

        public void CommitTransaction()
        {
            if (_context is null)
                throw new InvalidOperationException("There is not an open transaction to commit.");

            _context.SaveChanges();
            _context.Dispose();
            _context = null;
        }

        public void PartialCommit()
        {
            if (_context is null)
                throw new InvalidOperationException("There is not an open transaction to commit.");
            _context.SaveChanges();
        }

        public void RollbackTransaction()
        {
            if (_context is null)
                throw new InvalidOperationException("There is not an open transaction to rollback.");
            _context.Dispose();
            _context = null;
        }
    }
}

