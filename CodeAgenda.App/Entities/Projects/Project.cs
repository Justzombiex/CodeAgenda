using CodeAgenda.Domain.Entities.Activities;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Projects
{
    public class Project : Entity
    {
        #region Properties

        /// <summary>
        /// Name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Progress based on completed activities
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Start date of the project.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Estimated date of the project.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// List of activities related to the project
        /// </summary>
        public List<Activity> activities = new List<Activity>();

        /// <summary>
        /// Tags related to the project
        /// </summary>
        public List<Tag> tagsProject = new List<Tag>();

        /// <summary>
        /// Notes related to the project
        /// </summary>
        public List<Note> notesProject = new List<Note>();

        /// <summary>
        /// Notifications
        /// </summary>
        public List<Notification> Notifications { get; } = new List<Notification>();

        #endregion Properties

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Project() { }

        public Project(string name, string description, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
