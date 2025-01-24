using CodeAgenda.DataAccess.Abstract;
using CodeAgenda.Domain.Entities.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories.Assignments
{
    public interface IAssignmentRepository
    {
        /// <summary>
        /// Add an assignment in the DB.
        /// </summary>
        /// <param name="assignment">Assignment to add.</param>
        void Add(Assignment assignment);

        /// <summary>
        /// Gets an Assignment from DB.
        /// </summary>
        /// <param name="id">Assignment Id</param>
        /// <returns> Assignment to exist in DB, otherwise <see langword="null"/></returns>
        Assignment? GetById(Guid id);

        /// <summary>
        /// Gets all Assignments from DB.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Assignment> GetAll();

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
