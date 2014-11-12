using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRestHotels
{
    public class GuestListDTO
    {
        public string HotelName { get; set; }
        public int RoomNo { get; set; }
        public string GuestName { get; set; }

        public override string ToString()
        {
            return string.Format("HotelName: {0}, RoomNo: {1}, GuestName: {2}", HotelName, RoomNo, GuestName);
        }
    }
}