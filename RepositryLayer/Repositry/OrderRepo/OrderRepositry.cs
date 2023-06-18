using DataLayer;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositryLayer.Repositry.OrderRepo
{
    public class OrderRepositry : IOrderRepositry
    {
        private readonly ApplicationDbContext dbContext;
        public OrderRepositry(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<OrderDTO>> GetOrders()
        {
            var orders = await dbContext.Orders.Include(o => o.Customer).Include(o => o.Details).ToListAsync();
            var listOfOrders = new List<OrderDTO>();

            foreach (Order order in orders)
            {
                OrderDTO orderDTO = new OrderDTO();
                orderDTO.Id = order.Id;
                orderDTO.OrderNumber = order.OrderNumber;
                orderDTO.CustomerId = order.CustomerId;
                orderDTO.CustomerName = order.Customer.Name;
                orderDTO.OrderStatus = (OrderStatusEnum)order.OrderStatus;
                orderDTO.TotalPrice = order.TotalPrice;
                orderDTO.orderDetails = new List<OrderDetailDTO>();
                foreach (var item in order.Details)
                {
                    OrderDetailDTO orderDetailDTO = new OrderDetailDTO()
                    {
                        Id = item.Id,
                        ItemId = item.ItemId,
                        OrderId = item.OrderId,
                        Price = item.Price,
                        Tax = item.Tax,
                        Quantity= item.Quantity,
                    };
                    orderDTO.orderDetails.Add(orderDetailDTO);
                }

                listOfOrders.Add(orderDTO);
            }
            return listOfOrders;
        }

        public Order GetOrderById(int id)
        {
            Order orderById = dbContext.Orders.AsNoTracking().FirstOrDefault(o => o.Id == id);
            return orderById;
        }

        public async Task<Order> AddOrder(OrderDTO input)
        {
            Order order = new Order()
            {
                Id = input.Id,
                CreatedAt = DateTime.Now,
                CustomerId = input.CustomerId,
                OrderNumber = input.OrderNumber,
                OrderStatus = (int)input.OrderStatus,
                TotalPrice = input.TotalPrice

            };

            await dbContext.Orders.AddAsync(order);
            return order;

        }
        public async Task<Order> UpdateOrder(OrderDTO input)
        {
            Order order = new Order()
            {
                Id = input.Id,
                CustomerId = input.CustomerId,
                OrderNumber = input.OrderNumber,
                UpdatedAt = DateTime.Now,
                TotalPrice = input.TotalPrice,
                OrderStatus = (int)input.OrderStatus
            };

            dbContext.Entry(order).State = EntityState.Modified;
            return order;
        }

        public async Task DeleteOrder(int Id)
        {
            Order order = await dbContext.Orders.FindAsync(Id);
            dbContext.Orders.Remove(order);
        }


    }
}
