using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService:IOrderService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderService(ApplicationDbContext applicationDb)
        {
            applicationDbContext = applicationDb;

        }

        public async Task<Order> GetOrder()
        {
            return applicationDbContext.Orders.OrderByDescending(u => u.Price).FirstOrDefault();
        }

        public async  Task<List<Order>> GetOrders()
        {
            List<Order> orders =  applicationDbContext.Orders.Where(u => u.Quantity>10).ToList();

            return  orders;
        }
    }
}
