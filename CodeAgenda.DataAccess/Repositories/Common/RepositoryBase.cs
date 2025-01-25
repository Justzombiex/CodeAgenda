using CodeAgenda.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories.Common
{
    /// <summary>
    /// Base class for repositories.
    /// </summary>
    public abstract class RepositoryBase
    {
        /// <summary>
        /// DB context.
        /// </summary>
        protected ApplicationContext _context;

        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
    }
}
