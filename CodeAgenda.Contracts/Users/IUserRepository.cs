using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.DataAccess.Abstract.Users
{
    public interface IUserRepository
    {
        /// <summary>
        /// Add an User in the DB.
        /// </summary>
        /// <param name="user">User to add.</param>
        void Add(User user);

        /// <summary>
        /// Gets a User from DB.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns> User to exist in DB, otherwise <see langword="null"/></returns>
        User? GetById(Guid id);

        /// <summary>
        /// Gets all Users from DB.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<User> GetAll();

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
