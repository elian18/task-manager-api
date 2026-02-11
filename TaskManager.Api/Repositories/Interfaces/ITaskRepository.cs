using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;

namespace TaskManager.Api.Repositories.Interfaces
{
    public interface ITaskRepository : IRepository<TaskItem>
    {
        Task<List<TaskResponse>> GetTasksByUserId(Guid Id);
        Task<TaskItem?> GetTaskById(Guid id);
        Task<TaskItem> UpdateTask(TaskItem task);
        Task<TaskItem> UpdateTaskStatus(TaskItem task);
    }
}
