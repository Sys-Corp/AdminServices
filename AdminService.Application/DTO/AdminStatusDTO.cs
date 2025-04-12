using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.Application.DTO
{
    public class AdminStatusCreateDTO
    {
        [StringLength(80)]
        [Required]
        public string description { get; set; }
    }
    public class AdminStatusUpdateDTO
    {
        [Required]
        public int id { get; set; }
        [StringLength(80)]
        [Required]
        public string description { get; set; }
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
}
