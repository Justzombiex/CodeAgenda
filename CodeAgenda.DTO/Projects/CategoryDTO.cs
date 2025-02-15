using System.Drawing;

namespace CodeAgenda.DTO.Projects
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
    }

}
