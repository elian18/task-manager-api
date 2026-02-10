using TaskManager.Api.Models;
using TaskManager.Api.Repositories.Interfaces;
using TaskManager.Api.Services.Interfaces;

namespace TaskManager.Api.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IUserRepository userRepository;

        public TaskService(
            ITaskRepository taskRepository,
            IUserRepository userRepository)
        {
            this.taskRepository = taskRepository;
            this.userRepository = userRepository;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await taskRepository.GetAllAsync();
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            var userExists = await userRepository.GetByIdAsync(task.UserId);
            if (userExists == null)
                throw new Exception("User does not exist");

            task.CreatedAt = DateTime.UtcNow;
            await taskRepository.CreateAsync(task);
        }

    }
}
