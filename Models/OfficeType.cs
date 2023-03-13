using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserModuleApi.Models
{
    public class OfficeType
    {
        [Key]
        public int OfficeTypeId { get; set; }
        [Required]
        public string OfficeTypeName { get; set; }
        [Required]
        public string OfficeTypeNameShort { get; set; }
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
