using DataLayer.DTO;
using DataLayer.Models;

namespace RepositryLayer.Repositry.OrderDetails
{
    public interface IOrderDetailsRepositry
    {
        Task AddOrderDetails(OrderDTO input, Order order);
        Task DeleteOrder(int Id);
        Task<List<OrderDetail>> GetOrders();
        Task UpdateOrderDetails(OrderDTO input, Order order);
    }
}