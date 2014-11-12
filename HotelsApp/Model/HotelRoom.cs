using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsApp.Model
{
    public class HotelRoom
    {
        public int Hotel_No { get; set; }
        public string Name { get; set; }
        public int Room_No { get; set; }
        public string Types { get; set; }
        public double Price { get; set; }

        public HotelRoom(int hotelNo, string name, int roomNo, string types, double price)
        {
            Hotel_No = hotelNo;
            Name = name;
            Room_No = roomNo;
            Types = types;
            Price = price;
        }

        public HotelRoom()
        {
            
        }

        public override string ToString()
        {
            return string.Format("Hotel_No: {0}, Name: {1}, Room_No: {2}, Types: {3}, Price: {4}", Hotel_No, Name, Room_No, Types, Price);
        }
    }
}
