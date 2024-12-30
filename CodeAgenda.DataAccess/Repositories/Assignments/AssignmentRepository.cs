using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public partial class ApplicationRepository : IAssignmentRepository
    {
        public Assignment CreateAssignment(string name, string description, DateTime finishDate, Status status)
        {
            Assignment Assignment = new Assignment(name, description, finishDate, status);
            _context.Add(Assignment);
            return Assignment;
        }

        Assignment? IAssignmentRepository.Get(int id)
        {
            return _context.Set<Assignment>().Find(id);
        }

        public void Update(Assignment Assignment)
        {
            _context.Set<Assignment>().Update(Assignment);
        }

        public void Delete(Assignment Assignment)
        {
            _context.Remove(Assignment);
        }
    }
}
