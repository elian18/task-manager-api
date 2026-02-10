using System;
using TaskManager.Api.Data;
using TaskManager.Api.Models;
using TaskManager.Api.Repositories.Interfaces;

namespace TaskManager.Api.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor) : base(serviceProvider, httpContextAccessor)
        {
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var result = ( from db in context.Set<User>()
                                 where db.Id == id
                                 select db).FirstOrDefault();
            return result;
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            var result = ( from db in context.Set<User>()
                                 where db.Email == email
                                 select db).FirstOrDefault();
            return result;
        }
    }
}
