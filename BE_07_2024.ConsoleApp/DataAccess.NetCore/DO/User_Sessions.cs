using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class User_Sessions
    {
        [Key]
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public string DeviceID { get; set; }
        public string Location { get; set; }
        public string DeviceName { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
