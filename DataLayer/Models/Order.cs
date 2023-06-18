using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer.Models
{
    public class Order:BaseInfo
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public CustomerInfo Customer { get; set; }

        [Column(TypeName = "decimal(18,2)")]

        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public string OrderNumber { get; set; }
        
        public virtual ICollection<OrderDetail> Details { get; set; }= new List<OrderDetail>() ;

    }
}
