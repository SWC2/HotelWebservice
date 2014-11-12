using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelsApp.Model;
using HotelsApp.Util;
using HotelsApp.ViewModel;

namespace HotelsApp.Handler
{
    class HotelHandler
    {
        public HotelViewModel HotelViewModel { get; set; }

        public HotelHandler(HotelViewModel hotelViewModel)
        {
            HotelViewModel = hotelViewModel;
        }

        public void SetSelectedHotel(Hotel hotel)
        {
            HotelViewModel.SelectedHotel = hotel;
        }

        public void CreateHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = HotelViewModel.Name;
            hotel.Address = HotelViewModel.Address;
            new PersistenceFacade().SaveHotel(hotel);
            //HotelViewModel.Hotels.Hotels.Add(hotel);
            var hotels = new PersistenceFacade().GetHotels();
            HotelViewModel.Hotels.Hotels.Clear();
            foreach (var hotel1 in hotels)
            {
                HotelViewModel.Hotels.Hotels.Add(hotel1);
            }
            HotelViewModel.Name = "";
            HotelViewModel.Address = "";
        }

        
        public async void DeleteHotel()
        {

            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("Are you sure you want to Delete the Hotel: " + HotelViewModel.SelectedHotel.Name +" ?");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();

           
           
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            new PersistenceFacade().DeleteHotel(HotelViewModel.SelectedHotel.Hotel_No); 
            HotelViewModel.Hotels.Hotels.Remove(HotelViewModel.SelectedHotel);
        }



    }
}
