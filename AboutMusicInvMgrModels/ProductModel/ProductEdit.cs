using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMusicInvMgr.Models.Product
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ModelNumber { get; set; }
        public bool IsAvalibleOnline { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
