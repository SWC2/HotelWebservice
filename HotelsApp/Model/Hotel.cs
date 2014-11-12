using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelsApp.Model
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public int Hotel_No { get; set; }
    
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        public Hotel(int hotelNo, string name, string address)
        {
            Hotel_No = hotelNo;
            Name = name;
            Address = address;
        }

        public Hotel()
        {
            
        }

        //public override string ToString()
        //{
        //    return string.Format("Hotel_No: {0}, Name: {1}, Address: {2}", Hotel_No, Name, Address);
        //}

        public override string ToString()
        {
            return string.Format("Hotel_No: {0}, Name: {1}, Address: {2}", Hotel_No, Name, Address);
        }
    }
}
