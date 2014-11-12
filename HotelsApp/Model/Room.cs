using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core.AnimationMetrics;

namespace HotelsApp.Model
{
    public class Room
    {
        public int RoomNo { get; set; }
        public int HotelNo { get; set; }
        public string Types { get; set; }
        public double Price { get; set; }

        public Room(int roomNo, int hotelNo, string types, double price)
        {
            RoomNo = roomNo;
            HotelNo = hotelNo;
            Types = types;
            Price = price;
        }

        public Room()
        {
            
        }

        public override string ToString()
        {
            return string.Format("RoomNo: {0}, Hotel_No: {1}, Types: {2}, Price: {3}", RoomNo, HotelNo, Types, Price);
        }
    }
}
