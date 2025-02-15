using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DTO.Assignments
{
    public class TagProjectDTO
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
    }

}
