using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Assignments
{
    public class TagProject : Tag
    {
        /// <summary>
        /// Project associated with the tag
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Project's id associated with the tag
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Tags and Projects relation
        /// </summary>
        public List<TagProjectsRelation> TagProjectRelations;

        public TagProject(string name,
            Color color,
            Project project,
            Guid id)
            : base(name, color, id)
        {
            Project = project;
            ProjectId = project.Id;
            TagProjectRelations = new();
        }
    }
}
