using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public partial class ApplicationRepository : INotificationRepository
    {
        /// <summary>
        /// Create a Notification in the DB.
        /// </summary>
        /// <param name="message">Message of the notification.</param>
        /// <param name="reminderDate">Reminder date of the notification</param>
        /// <param name="isRead">Indicates if the notification is read</param>
        /// <param name="projectId">Project associated Id</param>
        public Notification CreateNotification(string message, DateTime reminderDate, bool isRead, int projectId)
        {
            Notification notification = new Notification(message, reminderDate, isRead, projectId);
            _context.Add(notification);
            return notification;
        }

        /// <summary>
        /// Gets a Notification from DB.
        /// </summary>
        /// <param name="id">Notification Id</param>
        /// <returns> Notification to exist in DB, otherwise <see langword="null"/></returns>
        Notification? INotificationRepository.Get(int id)
        {
            return _context.Set<Notification>().Find(id);
        }

        /// <summary>
        /// Update a Notification in the DB.
        /// </summary>
        /// <param name="Notification">Notification to update.</param>
        public void Update(Notification Notification)
        {
            _context.Set<Notification>().Update(Notification);
        }

        /// <summary>
        /// Delete a Notification in the DB.
        /// </summary>
        /// <param name="Notification">Notification to delete.</param>
        public void Delete(Notification Notification)
        {
            _context.Remove(Notification);
        }
    }
}
