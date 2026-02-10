using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;
using TaskManager.Api.Repositories.Interfaces;

namespace TaskManager.Api.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext context;

        public TaskRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await context.Tasks
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await context.Tasks
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateAsync(TaskItem task)
        {
            context.Tasks.Add(task);
            await context.SaveChangesAsync();
        }
    }
}
