using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;
using TaskManager.Api.Repositories.Interfaces;

namespace TaskManager.Api.Repositories.Implementations
{
    public class TaskRepository : Repository<TaskItem>, ITaskRepository
    {
        public TaskRepository(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor) : base(serviceProvider, httpContextAccessor)
        {
        }

        public async Task<List<TaskResponse>> GetTasksByUserId(Guid Id)
        {
            var result = await (from db in context.Set<TaskItem>()
                          join user in context.Set<User>() on db.UserId equals user.Id
                          where db.UserId == Id
                          orderby db.CreatedAt descending
                          select new TaskResponse
                            {
                                Id = db.Id,
                                Title = db.Title,
                                Description = db.Description,
                                Status = db.Status.ToString()
                            }).ToListAsync();
            return result;
        }
        public async Task<TaskItem?> GetTaskById(Guid id)
        {
            var result = (from db in context.Set<TaskItem>()
                          where db.Id == id
                          select db).FirstOrDefault();
            return result;
        }

        public async Task<TaskItem> UpdateTask(TaskItem task)
        {
            return await Update(task);
        }

        public async Task<TaskItem> UpdateTaskStatus(TaskItem task)
        {
            return await Update(task);
        }

        public async Task<TaskItem> DeleteTask(Guid id)
        {
            return await Delete(id);
        }
    }
}
