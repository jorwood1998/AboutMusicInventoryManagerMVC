using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMusicInvMgr.Models.Store
{
    public class StoreEdit
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Hours { get; set; }
        public string PhoneNumber { get; set; }
        public bool HasOnlineProducts { get; set; }
    }
}
