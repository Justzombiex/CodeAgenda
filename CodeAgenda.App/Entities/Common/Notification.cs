using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Common
{
    public class Notification : Entity
    {
        #region Properties

        /// <summary>
        /// The message of the notification .
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The date and time when the notification is scheduled to be sent.
        /// </summary>
        public DateTime ReminderDate { get; set; }

        /// <summary>
        /// Indicates whether the notification has been read by the user.
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// The project to which this note is associated.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// The unique identifier of the project associated with this notification.
        /// </summary>
        public Guid ProjectId { get; set; }

        #endregion Properties

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Notification() { }

        /// <summary>
        /// Instance a Notification object.
        /// </summary>
        /// <param name="message">Message of the notification.</param>
        /// <param name="reminderDate">Reminder date of the notification</param>
        /// <param name="isRead">Indicates if the notification is read</param>
        /// <param name="projectId">The unique identifier for the notification</param>
        public Notification(
            string message,
            DateTime reminderDate,
            bool isRead,
            Guid id)
            : base(id)
        {
            Message = message;
            ReminderDate = reminderDate;
            IsRead = isRead;
        }
    }
}
