using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Types;

namespace CodeAgenda.Domain.Entities.Assignments
{
    public class Assignment : Entity
    {
        #region Properties

        /// <summary>
        /// Name of the Assignment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the Assignment, could be empty.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Finish of the Assignment.
        /// </summary>
        public DateTime FinishDate { get; set; }

        /// <summary>
        /// Status of the Assignment.
        /// </summary>
        public Status Status { get; set;}

        /// <summary>
        /// Priority of the Assignment.
        /// </summary>
        public Priority Priority { get; set;}

        /// <summary>
        /// Tags related to the Assignment.
        /// </summary>
        [NotMapped]
        public List<Tag> TagsAssignment = new List<Tag>();

        /// <summary>
        /// Notes related to the Assignment.
        /// </summary>
        [NotMapped]
        public List<Note> NotesAssignment= new List<Note>();

        #endregion

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Assignment() { }

        /// <summary>
        /// Instance an object of Assignment.
        /// </summary>
        /// <param name="name">Name of the Assignment.</param>
        /// <param name="description">Description of the Assignment, could be empty.</param>
        /// <param name="finishDate">Finish of the Assignment.</param>
        /// <param name="status">Status of the Assignment.</param>
        public Assignment(string name, string description, DateTime finishDate, Status status)
        {
            Name = name;
            Description = description;
            FinishDate = finishDate;
            Status = status;
        }
    }
}
