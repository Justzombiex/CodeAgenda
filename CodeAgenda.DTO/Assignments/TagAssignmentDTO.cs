using System.Drawing;

namespace CodeAgenda.DTO.Assignments
{
    public class TagAssignmentDTO
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Guid AssignmentId { get; set; }
        public Guid Id { get; set; }
    }

}
