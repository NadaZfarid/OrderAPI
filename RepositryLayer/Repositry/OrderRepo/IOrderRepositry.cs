using DataLayer.DTO;
using DataLayer.Models;

namespace RepositryLayer.Repositry.OrderRepo
{
    public interface IOrderRepositry
    {
        Task<Order> AddOrder(OrderDTO input);
        Task DeleteOrder(int Id);
        Task<List<OrderDTO>> GetOrders();
        Order GetOrderById(int id);
        Task<Order> UpdateOrder(OrderDTO input);
    }
}