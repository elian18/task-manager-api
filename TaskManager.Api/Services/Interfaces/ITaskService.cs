using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;
using TaskManager.Api.Models.DTOs;

namespace TaskManager.Api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResponse> GetTaskById(Guid id);
        Task<List<TaskResponse>> GetTasksByUserId(Guid userId);
        Task<IActionResult> CreateTask(TaskRequest taskRequest);
        Task<IActionResult> UpdateTask(Guid id, TaskUpdateRequest taskUpdateRequest);
        Task<IActionResult> UpdateTaskStatus(Guid id, TaskStatusUpdateRequest taskStatusUpdateRequest);
    }
}
