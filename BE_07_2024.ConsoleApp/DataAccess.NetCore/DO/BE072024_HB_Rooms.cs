using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class BE072024_HB_Rooms
    {
        [Key] // tương ưng PRIMARY KEY TRONG DATABASE CỦA CỘT RoomID
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string? RoomNumber { get; set; }
        public int RoomSquare { get; set; }
        public int IsActive { get; set; }

        // nhấn phím ALT + KÉO CHUỘT

        
    }

    public class HB_RoomGetAllRequestData
    {
        public string? RoomNumber { get; set; }
    }

    public class Room_InsertRequestData
    {
        public int HotelID { get; set; }
        public string? RoomNumber { get; set; }
        public int RoomSquare { get; set; }
        public int IsActive { get; set; }
    }

}
