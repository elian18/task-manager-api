using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;
using TaskManager.Api.Models.DTOs;
using TaskManager.Api.Services.Interfaces;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/task-service")]
    public class TaskServiceController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITaskService taskService;

        public TaskServiceController(
            IUserService userService,
            ITaskService taskService
        )
        {
            this.userService = userService;
            this.taskService = taskService;
        }

        // ---------------- USERS ----------------

        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var user = await userService.CreateUserAsync(dto);

            return Created("", new
            {
                user.Id,
                user.Email,
                user.CreatedAt
            });
        }

        // ---------------- TASKS ----------------

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                UserId = dto.UserId
            };

            await taskService.CreateTaskAsync(task);
            return Ok();
        }
    }
}
