using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Enums;
using TestTask.Data;
namespace TestTask.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserService(ApplicationDbContext applicationDb)
        {
            applicationDbContext = applicationDb;

        }

        public async Task<User> GetUser()
        {
            
            return applicationDbContext.Users.OrderByDescending(u => u.Orders.Count).FirstOrDefault();
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> inactiveUsers = applicationDbContext.Users.Where(u => u.Status == UserStatus.Inactive).ToList();

            return  inactiveUsers;
        }
    }
}
