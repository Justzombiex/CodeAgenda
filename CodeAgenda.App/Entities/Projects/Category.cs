using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Projects
{
    public class Category : Entity
    {
        #region Properties

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color associated with the category.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Associated project identifier.
        /// </summary>
        public int ProjectId { get; set; }

        #endregion Properties
      
        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Category() { }
        
        /// <summary>
        /// Instance an object of Category.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="color">The color associated with the category.</param>
        public Category(string name, Color color, int projectId)
        {
            Name = name;
            Color = color;
            ProjectId = projectId;
        }  
    }
}

