using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class OrderDTO
    {

        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatusEnum OrderStatus { get; set; }
        [Required]
        public string OrderNumber { get; set; }
     
        public List<OrderDetailDTO> orderDetails { get; set; }
    }
}
