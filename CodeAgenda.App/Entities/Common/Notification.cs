using CodeAgenda.Domain.Entities.Persons;
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
        /// The person who will receive this notification.
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Associated project identifier.
        /// </summary>
        public int ProjectId { get; set; }

        #endregion Properties

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Notification() { }

        public Notification(string message, DateTime reminderDate, bool isRead, Person person, int projectId)
        {
            Message = message;
            ReminderDate = reminderDate;
            IsRead = isRead;
            Person = person;
            ProjectId = projectId;
        }
    }
}
