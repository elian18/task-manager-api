namespace TaskManager.Api.Models.DTO
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
