using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DTO.Common
{
    public class TagProjectDTO
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
    }

}
