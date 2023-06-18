using DataLayer.Models;
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
    public class OrderDetailDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public decimal Price { get; set; }

        public decimal? Tax { get; set; }
        [Required]
        
        public int Quantity { get; set; }
    }
}
