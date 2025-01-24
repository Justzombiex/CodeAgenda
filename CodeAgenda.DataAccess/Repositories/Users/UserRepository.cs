using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Assignments;
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

        public void Add(User User)
        {
            _context.User.Add(User);
        }

        User? IUserRepository.GetById(Guid id)
        {
            return _context.Set<User>().Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public void Update(User User)
        {
            _context.User.Update(User);
        }

        public void Delete(User User)
        {
            _context.User.Remove(User);
        }
    }
}
