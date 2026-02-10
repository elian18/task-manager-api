using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task CreateAsync(TaskItem task);
    }
}
