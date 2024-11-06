using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class BE072024_HB_Hotels
    {
        [Key]
        public int HotelID { get; set; }
        public string? HotelName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        //public List<BE072024_HB_Rooms> bE072024_HB_Rooms { get; set; }
    }
}
