using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Types;

namespace CodeAgenda.Domain.Entities.Activities
{
    public class Activity : Entity
    {
        #region Properties

        /// <summary>
        /// Name of the activity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the activity, could be empty.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Finish of the activity.
        /// </summary>
        public DateTime FinishDate { get; set; }

        /// <summary>
        /// Status of the activity.
        /// </summary>
        public Status Status { get; set;}

        /// <summary>
        /// Priority of the activity.
        /// </summary>
        public Priority Priority { get; set;}

        /// <summary>
        /// Tags related to the activity.
        /// </summary>
        public List<string> TagsActivity = new List<string>();

        /// <summary>
        /// Notes related to the activity.
        /// </summary>
        public List<Note> NotesActivity= new List<Note>();

        #endregion

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Activity() { }

        /// <summary>
        /// Instance an object of Activity.
        /// </summary>
        /// <param name="name">Name of the activity.</param>
        /// <param name="description">Description of the activity, could be empty.</param>
        /// <param name="finishDate">Finish of the activity.</param>
        /// <param name="status">Status of the activity.</param>
        public Activity(string name, string description, DateTime finishDate, Status status)
        {
            Name = name;
            Description = description;
            FinishDate = finishDate;
            Status = status;
        }
    }
}
