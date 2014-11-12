using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSRestHotelsTestConsole
{
    class HotelRoom
    {
        public string Name { get; set; }

        public int Room_No { get; set; }

        public string Types { get; set; }

        public double? Price { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Room_No: {1}, Types: {2}, Price: {3}", Name, Room_No, Types, Price);
        }
    }
}
