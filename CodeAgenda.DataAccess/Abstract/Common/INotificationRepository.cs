using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract.Common
{
    internal interface INotificationRepository : IRepository
    {
        /// <summary>
        /// Create a Notification in the DB.
        /// </summary>
        /// <param name="message">Message of the notification.</param>
        /// <param name="reminderDate">Reminder date of the notification</param>
        /// <param name="isRead">Indicates if the notification is read</param>
        /// <param name="projectId">Project associated Id</param>
        Notification CreateNotification(string message, DateTime reminderDate, bool isRead, int projectId);

        /// <summary>
        /// Gets a Notification from DB.
        /// </summary>
        /// <param name="id">Notification Id</param>
        /// <returns> Notification to exist in DB, otherwise <see langword="null"/></returns>
        Notification? Get(int id);

        /// <summary>
        /// Update a Notification in the DB.
        /// </summary>
        /// <param name="Notification">Notification to update.</param>
        void Update(Notification Notification);

        /// <summary>
        /// Delete a Notification in the DB.
        /// </summary>
        /// <param name="Notification">Notification to delete.</param>
        void Delete(Notification Notification);
    }
}
