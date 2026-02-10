using TaskManager.Api.Repositories.Implementations;
using TaskManager.Api.Repositories.Interfaces;

namespace TaskManager.Api.DependencyInjection
{
    public class Repository
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}
