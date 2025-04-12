using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.Domain.Entities
{
    public class AdminStatus
    {
        [Key]
        public int id { get; set; }
        [StringLength(80)]
        public string description { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
}
