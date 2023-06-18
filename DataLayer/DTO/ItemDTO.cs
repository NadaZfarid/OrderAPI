using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 4)]
        public string Name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Code { get; set; }
        public decimal Price { get; set; }
       
    }
}
