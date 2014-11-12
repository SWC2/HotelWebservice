using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelsApp.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using HotelsApp.Util;

namespace HotelsApp.ViewModel
{
    public class GetHotelRoomsHandler
    {
        public ObservableCollection<Room> Rooms { get; set; }

        public GetHotelRoomsHandler(ObservableCollection<Room> rooms)
        {
            Rooms = rooms;
        }

        public void GetRooms(Hotel hotel)
        {
             var hotelroomList =  new PersistenceFacade().GetRooms(hotel);
             Rooms.Clear();
             foreach (var hotelroom in hotelroomList.ToList())
             {
                  Rooms.Add(new Room(hotelroom.Room_No, hotelroom.Hotel_No, hotelroom.Types, hotelroom.Price));
             }
        }
    }
}

