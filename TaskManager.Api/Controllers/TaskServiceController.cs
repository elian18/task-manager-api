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
    }
}
