using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMusicInvMgrModels.StoreModel
{
    public class StoreList
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Hours { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool HasOnlineProducts { get; set; }
    }
}
