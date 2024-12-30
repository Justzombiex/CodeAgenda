using CodeAgenda.DataAccess.Abstract;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories.Assignments
{
    public interface IAssignmentRepository : IRepository
    {
        /// <summary>
        /// Create an Assignment in DB.
        /// </summary>
        /// <param name="name">The name of the Assignment</param>
        /// <param name="description">The description of the Assignment</param>
        /// <param name="finishDate">The finish dae of the Assignment</param>
        /// <param name="status">The status of the Assignment</param>
        /// <returns></returns>
        Assignment CreateAssignment(string name, string description, DateTime finishDate, Status status);

        /// <summary>
        /// Gets an Assignment from DB.
        /// </summary>
        /// <param name="id">Assignment Id</param>
        /// <returns> Assignment to exist in DB, otherwise <see langword="null"/></returns>
        Assignment? Get(int id);

        /// <summary>
        /// Update an Assignment in the DB.
        /// </summary>
        /// <param name="Assignment">Assignment to update.</param>
        void Update(Assignment Assignment);

        /// <summary>
        /// Delete an Assignment in the DB.
        /// </summary>
        /// <param name="Assignment">Assignment to delete.</param>
        void Delete(Assignment Assignment);
    }
}
