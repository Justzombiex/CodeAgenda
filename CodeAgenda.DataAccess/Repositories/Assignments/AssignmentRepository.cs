using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Assignments;

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

        public void Add(Assignment assignment)
        {
            _context.Assignment.Add(assignment);
        }

        public void Delete(Assignment Assignment)
        {
            _context.Assignment.Remove(Assignment);
        }

        public Assignment? GetById(Guid id)
        {
            var assignment = _context.Assignment.FirstOrDefault(x => x.Id == id);
            if (assignment == null)
            {
                throw new Exception("Assignment not found");
            }
            return assignment;
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
