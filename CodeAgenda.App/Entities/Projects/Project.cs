using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// Progress based on completed Assignments
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
        /// Category of the project.
        /// </summary>
        [NotMapped]
        public Category Category { get; set; }

        /// <summary>
        /// User of the project
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The unique identifier for the user
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// List of Assignments related to the project
        /// </summary>
        [NotMapped]
        public List<Assignment> Assignments;

        /// <summary>
        /// Tags related to the project
        /// </summary>
        [NotMapped]
        public List<Tag> Tags;

        /// <summary>
        /// Notes related to the project
        /// </summary>
        [NotMapped]
        public List<Note> Notes;

        /// <summary>
        /// Notifications
        /// </summary>
        [NotMapped]
        public List<Notification> Notifications;

        #endregion Properties

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Project() { }

        /// <summary>
        /// Instance a Project object
        /// </summary>
        /// <param name="name">Name of the project</param>
        /// <param name="description">Description of the project</param>
        /// <param name="startDate">Start date of the project</param>
        /// <param name="endDate">End date of the project</param>
        /// <param name="id">The unique identifier for the project</param>
        public Project(string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            Guid id) :
            base(id)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Progress = 0;
            Assignments = new List<Assignment>();
            Tags = new List<Tag>();
            Notes = new List<Note>();
            Notifications = new List<Notification>();

        }
    }
}
