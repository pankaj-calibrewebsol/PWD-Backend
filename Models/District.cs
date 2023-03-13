using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserModuleApi.Models
{
    public class District
    {
        [Key]
        public int DisttId { get; set; }
        [Required]
        public int StateId { get; set; }
        
        [Required]
        public string DistName { get; set; }

        [Required]
        public string DistShortName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int Updateby { get; set; }
        [Required]
        public DateTime Updateon { get; set; } = DateTime.UtcNow;
        [Required]
        public string IPAddress { get; set; }
    }
}
