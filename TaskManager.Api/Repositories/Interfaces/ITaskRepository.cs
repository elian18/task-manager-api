using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories.Interfaces
{
    public interface ITaskRepository : IRepository<TaskItem>
    {
        Task<TaskItem?> GetTaskById(Guid id);
    }
}
