using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRestHotels
{
    public class GuestListDetailedDTO
    {
        public string HotelName { get; set; }
        public int RoomNo { get; set; }
        public string GuestName { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public override string ToString()
        {
            return string.Format("HotelName: {0}, RoomNo: {1}, GuestName: {2}, DateFrom: {3}, DateTo: {4}", HotelName, RoomNo, GuestName, DateFrom.ToString("yyyy-mm-dd"), DateTo.ToString("yyyy-mm-dd"));
        }
    }
}