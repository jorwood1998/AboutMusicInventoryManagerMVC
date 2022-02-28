using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMusicInvMgrData
{
    public class StoreData
    {
        [Key]
        public int StoreId { get; set; }
        public Guid AdminId { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string Location { get; set; }
        public string State { get; set; }
        public string Hours { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool HasOnlineProducts { get; set; }
    }
}
