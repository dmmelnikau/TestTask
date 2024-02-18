using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService:IOrderService
    {
        public IEnumerable<Order> Orders { get; private set; }
        public async Task<Order> GetOrder()
        {
            return Orders.OrderByDescending(u => u.Price).FirstOrDefault();
        }

        public async  Task<List<Order>> GetOrders()
        {
            List<Order> orders = Orders.Where(u => u.Quantity>10).ToList();

            return orders;
        }
    }
}
