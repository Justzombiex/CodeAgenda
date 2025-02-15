namespace CodeAgenda.DTO.Common
{
    public class NoteAssignmentDTO
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Guid UserId { get; set; }
        public Guid AssignmentId { get; set; }
        public Guid Id { get; set; }
    }

}
