using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMusicInvMgr.Models.Product
{
    public class ProductCreate
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ModelNumber { get; set; }
        public string Location { get; set; }
        [Required]
        public bool IsAvalibleOnline { get; set; }
        public string Manufacturer { get; set; }
    }
}
