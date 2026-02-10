using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Models.DTOs
{
    public class TaskRequest
    {
        [Required]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public Types.TaskStatus Status { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
