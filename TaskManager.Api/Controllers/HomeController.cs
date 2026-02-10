using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Task Manager API running 🚀");
        }
    }
}
