namespace BE_072024.WebAspNetCoreMVC.Models
{
    public class HB_RoomGetAllRequestData
    {
        public string? RoomNumber { get; set; }
    }

    public class BE072024_HB_Rooms
    {
        
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string? RoomNumber { get; set; }
        public int RoomSquare { get; set; }
        public int IsActive { get; set; }


    }
}
