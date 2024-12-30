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
        /// Associated user identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// List of Assignments related to the project
        /// </summary>
        [NotMapped]
        public List<Assignment> Assignments = new List<Assignment>();

        /// <summary>
        /// Tags related to the project
        /// </summary>
        [NotMapped]
        public List<Tag> tagsProject = new List<Tag>();

        /// <summary>
        /// Notes related to the project
        /// </summary>
        [NotMapped]
        public List<Note> notesProject = new List<Note>();

        /// <summary>
        /// Notifications
        /// </summary>
        [NotMapped]
        public List<Notification> Notifications { get; } = new List<Notification>();

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
        /// <param name="userId">User associated id</param>
        public Project(string name, string description, DateTime startDate, DateTime endDate, int userId)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            UserId = userId;
        }
    }
}
