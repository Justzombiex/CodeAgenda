namespace CodeAgenda.DTO.Projects
{
    public class NotificationDTO
    {
        public string Message { get; set; }
        public DateTime ReminderDate { get; set; }
        public bool IsRead { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
    }

}
