using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;
using TaskManager.Api.Models.DTOs;
using TaskManager.Api.Services.Interfaces;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/manage")]
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

        [HttpGet("task")]
        public async Task<TaskResponse> GetTaskById([FromQuery] Guid id)
        {
            return await taskService.GetTaskById(id);
        }

        [HttpGet("users")]
        public async Task<List<UserResponse>> GetAllUsers()
        {
            return await userService.GetAllUsers();
        }

        [HttpGet("user/email")]
        public async Task<UserResponse> GetUserByEmail([FromQuery] string email)
        {
            return await userService.GetUserByEmail(email);
        }

        [HttpGet("user")]
        public async Task<UserResponse> GetUserById([FromQuery] Guid id)
        {
            return await userService.GetUserById(id);
        }

        [HttpGet("user/tasks")]
        public async Task<List<TaskResponse>> GetTasksByUserId([FromQuery] Guid userId)
        {
            return await taskService.GetTasksByUserId(userId);
        }

        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest)
        {
            return await userService.CreateUser(userRequest);
        }

        [HttpPost("task")]
        public async Task<IActionResult> CreateTask([FromBody] TaskRequest taskRequest)
        {

           return await taskService.CreateTask(taskRequest);
        }

        [HttpPut("task")]
        public async Task<IActionResult> UpdateTask([FromQuery] Guid id, [FromBody] TaskUpdateRequest taskUpdateRequest)
        {
            return await taskService.UpdateTask(id, taskUpdateRequest);
        }
    }
}
