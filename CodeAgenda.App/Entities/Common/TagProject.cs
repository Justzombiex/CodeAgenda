using CodeAgenda.Domain.Entities.Projects;
using System.Drawing;

namespace CodeAgenda.Domain.Entities.Common
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
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected TagProject() { }

        public TagProject(string name,
            Color color,
            Project project,
            Guid id)
            : base(name, color, id)
        {
            Project = project;
            ProjectId = project.Id;
        }
    }
}
