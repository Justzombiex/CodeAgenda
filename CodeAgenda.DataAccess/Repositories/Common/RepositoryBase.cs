using CodeAgenda.DataAccess.Concrete;

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
