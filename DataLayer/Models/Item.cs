using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Item:BaseInfo
    {
        public string Name { get; set; }
        public string Code { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> Details { get; set; }


    }
}
