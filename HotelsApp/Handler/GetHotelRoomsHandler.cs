using System.Collections.ObjectModel;
using System.Linq;
using HotelsApp.Model;
using HotelsApp.Util;

namespace HotelsApp.Handler
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

