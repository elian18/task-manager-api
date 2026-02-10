using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;
using TaskManager.Api.Repositories.Interfaces;

namespace TaskManager.Api.Repositories.Implementations
{
    public class TaskRepository : Repository<TaskItem>, ITaskRepository
    {
        public TaskRepository(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor) : base(serviceProvider, httpContextAccessor)
        {
        }

        public async Task<TaskItem?> GetTaskById(Guid id)
        {
            var result = (from db in context.Set<TaskItem>()
                          where db.Id == id
                          select db).FirstOrDefault();
            return result;
        }
    }
}
