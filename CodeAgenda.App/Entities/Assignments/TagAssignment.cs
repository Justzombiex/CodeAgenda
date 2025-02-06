using System.Drawing;

namespace CodeAgenda.Domain.Entities.Assignments
{
    public class TagAssignment : Tag
    {
        /// <summary>
        /// Assignemnt associated with the tag
        /// </summary>
        public Assignment Assignment { get; set; }

        /// <summary>
        /// Assignemnt's id associated with the tag
        /// </summary>
        public Guid AssignmentId { get; set; }

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected TagAssignment() { }

        public TagAssignment(string name,
            Color color,
            Assignment assignment,
            Guid id)
            : base(name, color, id)
        {
            Assignment = assignment;
            AssignmentId = Assignment.Id;
        }
    }
}
