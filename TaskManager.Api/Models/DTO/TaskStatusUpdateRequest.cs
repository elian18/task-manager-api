using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Models.DTOs
{
    public class TaskStatusUpdateRequest
    {
        [Required]
        public Types.TaskStatus Status { get; set; }
    }
}
