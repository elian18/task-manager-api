using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Models.DTOs
{
    public class TaskUpdateRequest
    {
        [Required]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public Types.TaskStatus Status { get; set; }
    }
}
