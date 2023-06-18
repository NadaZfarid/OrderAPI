using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryLayer.Repositry.OrderDetails
{
    public class OrderDetailsRepositry : IOrderDetailsRepositry
    {
        private readonly ApplicationDbContext dbContext;
        public OrderDetailsRepositry(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<OrderDetail>> GetOrders()
        {
            var ordersDetails = await dbContext.OrdersDetail.Include(od => od.Item).ToListAsync();
            return ordersDetails;
        }


        public async Task AddOrderDetails(OrderDTO input,Order order)
        {
            
            foreach (var item in input.orderDetails)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Id = item.Id,
                    OrderId = order.Id,
                    ItemId = item.ItemId,
                    Price = item.Price,
                    Tax = item.Tax,
                    Quantity = item.Quantity,
                };
                order.Details.Add(orderDetail);
            };

        }
        public async Task UpdateOrderDetails(OrderDTO input,Order order)
        {
            foreach (var item in input.orderDetails)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Id = item.Id,
                    OrderId = order.Id,
                    ItemId = item.ItemId,
                    Price = item.Price,
                    Tax = item.Tax,
                    Quantity = item.Quantity,
                };
                dbContext.Entry(orderDetail).State = EntityState.Modified;
            }; 
        }

        public async Task DeleteOrder(int Id)
        {
            OrderDetail orderDetails = await dbContext.OrdersDetail.FindAsync(Id);
            dbContext.OrdersDetail.Remove(orderDetails);
        }
    }
}
