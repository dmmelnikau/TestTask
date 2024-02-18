using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Enums;

namespace TestTask.Services.Implementations
{
    public class UserService:IUserService
    {
        public IEnumerable<User> Users { get; private set; }

        public async Task<User> GetUser()
        {
            
            return Users.OrderByDescending(u => u.Orders.Count).FirstOrDefault();
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> inactiveUsers = Users.Where(u => u.Status == UserStatus.Inactive).ToList();

            return inactiveUsers;
        }
    }
}
