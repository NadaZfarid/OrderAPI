using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class CustomerInfo:BaseInfo
    {
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }

        public virtual ICollection<Order>? Orders { get; set; } 

    }
}
