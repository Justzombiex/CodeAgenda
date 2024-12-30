using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Common;

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
        public Tag(string name, Color color) 
        { 
            Name = name; 
            Color = color; 
        }
    }
}
