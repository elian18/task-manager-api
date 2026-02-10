using TaskManager.Api.Models;

namespace TaskManager.Api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task CreateTaskAsync(TaskItem task);
    }
}
