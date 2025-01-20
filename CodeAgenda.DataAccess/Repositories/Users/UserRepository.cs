using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public class UserRepository 
        : RepositoryBase, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddUser(User User)
        {
            _context.User.Add(User);
        }

        /// <summary>
        /// Gets a User from DB.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns> User to exist in DB, otherwise <see langword="null"/></returns>
        User? IUserRepository.Get(Guid id)
        {
            return _context.Set<User>().Find(id);
        }

        /// <summary>
        /// Update a User in the DB.
        /// </summary>
        /// <param name="User">User to update.</param>
        public void Update(User User)
        {
            _context.User.Update(User);
        }

        /// <summary>
        /// Delete a User in the DB.
        /// </summary>
        /// <param name="User">User to delete.</param>
        public void Delete(User User)
        {
            _context.User.Remove(User);
        }
    }
}
