using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    /// <summary>
    /// Implementación del repositorio <see cref="IAssignmentRepository"/>.
    /// </summary>
    public class AssignmentRepository
        : RepositoryBase, IAssignmentRepository
    {
        public AssignmentRepository(ApplicationContext context) : base(context)
        {
        }

        public void Add(Assignment Assignment)
        {
            _context.Assignment.Add(Assignment);
        }

        public void Delete(Assignment Assignment)
        {
            _context.Assignment.Remove(Assignment);
        }

        public Assignment? GetById(Guid id)
        {
            return _context.Assignment.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Assignment> GetAll()
        {
            return _context.Assignment.ToList();
        }

        public void Update(Assignment Assignment)
        {
            _context.Assignment.Update(Assignment);
        }
    }
}
