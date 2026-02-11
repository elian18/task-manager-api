using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Exceptions;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;
using TaskManager.Api.Models.DTOs;
using TaskManager.Api.Repositories.Interfaces;
using TaskManager.Api.Services.Interfaces;
using TaskManager.Api.Types;

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
        public async Task<TaskResponse> GetTaskById(Guid id)
        {
            TaskItem task = await taskRepository.GetTaskById(id);
            if (task == null) throw new ArgumentException(Errors.TaskNotFound.ToString());
            return new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString()
            };
        }

        public async Task<List<TaskResponse>> GetTasksByUserId(Guid userId)
        {
            User user = await userRepository.GetUserById(userId);
            if (user == null) throw new ArgumentException(Errors.UserNotFound.ToString());
            return await taskRepository.GetTasksByUserId(userId);
        }

        public async Task<IActionResult> CreateTask(TaskRequest taskRequest)
        {
            User user = await userRepository.GetUserById(taskRequest.UserId);
            if (user == null) throw new ArgumentException(Errors.UserNotFound.ToString());

            TaskItem task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = taskRequest.Title,
                Description = taskRequest.Description,
                Status = taskRequest.Status,
                UserId = taskRequest.UserId,
                CreatedAt = DateTime.UtcNow
            };
            task = await taskRepository.Add(task);
            return await Task.FromResult(new OkObjectResult(new { Status = TypeStatus.SUCCESS.ToString() }));
        }

    }
}
