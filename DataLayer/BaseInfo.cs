using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BaseInfo
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }

        [MaxLength(36)]
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [MaxLength(36)]
        public string? UpdateBy { get; set; }
    }
}
