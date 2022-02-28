using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMusicInvMgrModels.ProductModel
{
    public class ProductListItem
    {
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public string Manufacturer { get; set; }
        public bool IsAvalibleOnline { get; set; }
        public string ModelNumber { get; set; }

    }
}
