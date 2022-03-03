using AboutMusicInvMgrModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AboutMusicInvMgrModels.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "UPC")]
        public int ProductId { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Description { get; set; }

        public int InventoryNumber { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual Employee Employees { get; set; }

    }
}