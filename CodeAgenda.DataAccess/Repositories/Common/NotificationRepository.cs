using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public class NotificationRepository 
        : RepositoryBase, INotificationRepository
    {
        public NotificationRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddNotification(Notification notification)
        {
            _context.Notification.Add(notification);
        }

        /// <summary>
        /// Gets a Notification from DB.
        /// </summary>
        /// <param name="id">Notification Id</param>
        /// <returns> Notification to exist in DB, otherwise <see langword="null"/></returns>
        Notification? INotificationRepository.Get(Guid id)
        {
            return _context.Set<Notification>().Find(id);
        }

        /// <summary>
        /// Update a Notification in the DB.
        /// </summary>
        /// <param name="Notification">Notification to update.</param>
        public void Update(Notification Notification)
        {
            _context.Notification.Update(Notification);
        }

        /// <summary>
        /// Delete a Notification in the DB.
        /// </summary>
        /// <param name="Notification">Notification to delete.</param>
        public void Delete(Notification Notification)
        {
            _context.Notification.Remove(Notification);
        }

    }
}
