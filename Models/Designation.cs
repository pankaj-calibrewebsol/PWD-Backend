using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserModuleApi.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        [Required]
        public int OfficeTypeId { get; set; }
        [Required]
        public int DesignationName { get; set; }
        [Required]
        public string DesignationShort { get; set; }
        [Required]
        public string DesignationOrderId { get; set; }
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
