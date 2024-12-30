using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public partial class ApplicationRepository : IUserRepository
    {
        /// <summary>
        /// Creates a user in DB.
        /// </summary>
        /// <param name="name">Name of the User.</param>
        /// <param name="firstName">First name of the User.</param>
        /// <param name="email">Email of the User.</param>
        public User CreateUser(string name, string firstName, string email)
        {
            User user = new User(name, firstName, email);
            _context.Add(user);
            return user;
        }

        /// <summary>
        /// Gets a User from DB.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns> User to exist in DB, otherwise <see langword="null"/></returns>
        User? IUserRepository.Get(int id)
        {
            return _context.Set<User>().Find(id);
        }

        /// <summary>
        /// Update a User in the DB.
        /// </summary>
        /// <param name="User">User to update.</param>
        public void Update(User User)
        {
            _context.Set<User>().Update(User);
        }

        /// <summary>
        /// Delete a User in the DB.
        /// </summary>
        /// <param name="User">User to delete.</param>
        public void Delete(User User)
        {
            _context.Remove(User);
        }
    }
}
