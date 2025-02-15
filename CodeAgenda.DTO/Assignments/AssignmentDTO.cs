using CodeAgenda.Domain.Entities.Types;

namespace CodeAgenda.DTO.Assignments
{
    public class AssignmentDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FinishDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
    }

}
