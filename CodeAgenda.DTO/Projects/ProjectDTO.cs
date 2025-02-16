namespace CodeAgenda.DTO.Projects
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserID { get; set; }

        
    }

}
