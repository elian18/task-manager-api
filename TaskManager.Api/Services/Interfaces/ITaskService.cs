using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTOs;

namespace TaskManager.Api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IActionResult> CreateTask(TaskRequest taskRequest);
    }
}
