using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

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
        public List<Assignment> Assignments;

        /// <summary>
        /// Notes related to the project
        /// </summary>
        public List<NoteProject> Notes;

        /// <summary>
        /// Notifications
        /// </summary>
        public List<Notification> Notifications;

        /// <summary>
        /// Tag and Projects relation
        /// </summary>
        public List<TagProject> Tags;

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
            User user,
            Guid id) :
            base(id)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Progress = 0;
            User = user;
            UserID = user.Id;
            Assignments = new();
            Notes = new();
            Notifications = new();
            Tags = new();

        }
    }
}
