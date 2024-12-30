using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract.Users
{
    public interface IUserRepository :IRepository
    {
        /// <summary>
        /// Creates a user in DB.
        /// </summary>
        /// <param name="name">Name of the User.</param>
        /// <param name="firstName">First name of the User.</param>
        /// <param name="email">Email of the User.</param>
        User CreateUser(string name, string firstName, string email);

        /// <summary>
        /// Gets a User from DB.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns> User to exist in DB, otherwise <see langword="null"/></returns>
        User? Get(int id);

        /// <summary>
        /// Update a User in the DB.
        /// </summary>
        /// <param name="User">User to update.</param>
        void Update(User User);

        /// <summary>
        /// Delete a User in the DB.
        /// </summary>
        /// <param name="note">User to delete.</param>
        void Delete(User User);
    }
}
