using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Domain.Entities.Assignments
{
    public class Tag : Entity
    {
        #region Properties

        /// <summary> 
        /// The name of the tag. 
        /// </summary> 
        public string Name { get; set; }
        /// <summary> 
        /// The color associated with the tag. 
        /// </summary> 
        public Color Color { get; set; }

        /// <summary>
        /// The assignments associated with this tag.
        /// </summary>
        [NotMapped]
        public List<Assignment> Assignments { get; private set; }

        /// <summary>
        /// The projects associated with this tag.
        /// </summary>
        [NotMapped]
        public List<Project> Projects { get; private set; }

        #endregion Properties

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Tag() { }

        /// <summary>
        /// Instance an object of Tag.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="color">The color associated with the tag.</param>
        /// <param name="id">The unique identifier for the tag</param>
        public Tag(string name,
            Color color,
            Guid id)
            : base(id)
        {
            Name = name;
            Color = color;
            Assignments = new List<Assignment>();
            Projects = new List<Project>();
        }
    }
}
