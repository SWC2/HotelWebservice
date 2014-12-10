using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using HotelsApp.Annotations;
using HotelsApp.Common;

using HotelsApp.Handler;
using HotelsApp.Model; 
using Windows.UI.Popups;
using RelayCommand = HotelsApp.Common.RelayCommand;

namespace HotelsApp.ViewModel
{
    class HotelViewModel : INotifyPropertyChanged
    {
        public static Hotel SelectedHotel { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(); }
        }

        public HotelCatalogSingleton Hotels { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
        public GetHotelRoomsHandler HotelRoomsHandler { get; set; }
        public HotelHandler HotelHandler { get; set; }

        private ICommand _newHotelCommand;
        public ICommand NewHotelCommand
        {
            get { if (_newHotelCommand==null)
                    _newHotelCommand = new RelayCommand(HotelHandler.CreateHotel);
                return _newHotelCommand; }
            set { _newHotelCommand = value; }
        }

        private ICommand _deleteHotelCommand;
        public ICommand DeleteHotelCommand
        {
           get
            {
                if (_deleteHotelCommand == null)
            //        _deleteHotelCommand = new RelayArgCommand<Hotel>(hotel => HotelHandler.DeleteHotel(hotel));
                      _deleteHotelCommand = new RelayCommand(HotelHandler.DeleteHotel);
                    return _deleteHotelCommand;
            }
            set { _deleteHotelCommand = value; }
        }

        //private ICommand _deleteHotelCommand;
        //public ICommand DeleteHotelCommand
        //{
        //    get
        //    {
        //        if (_deleteHotelCommand == null)
        //            _deleteHotelCommand = new RelayArgCommand<Hotel>(hotel => HotelHandler.DeleteHotel());
        //        return _newHotelCommand;
        //    }
        //    set { _deleteHotelCommand = value; }
        //}

        private ICommand _getHotelRoomCommand;
        private ICommand _selectHotelCommand;
        private static string _name;
        private static string _address;


        public ICommand SelectHotelCommand
        {
            get
            {
                if (_selectHotelCommand == null)
                    _selectHotelCommand = new RelayArgCommand<Hotel>(hotel => HotelHandler.SetSelectedHotel(hotel));
                return _selectHotelCommand;
            }
            set { _selectHotelCommand = value; }
        }


        public ICommand GetHotelRoomCommand
        {
            get
            {
                if (_getHotelRoomCommand == null)
                    _getHotelRoomCommand = new RelayArgCommand<Hotel>(hotel => HotelRoomsHandler.GetRooms(hotel));
                return _getHotelRoomCommand;
            }
            set { _getHotelRoomCommand = value; }
        }



        public HotelViewModel()
        {
            //Hotels = new ObservableCollection<Hotel>(new HotelDao().GetAllHotels());
            Hotels = HotelCatalogSingleton.Instance;
            Rooms = new ObservableCollection<Room>();
            HotelRoomsHandler = new GetHotelRoomsHandler(Rooms);
            HotelHandler = new HotelHandler(this);
            

            //const string ServerUrl = "http://localhost:30005";
            //HttpClientHandler handler = new HttpClientHandler();
            //handler.UseDefaultCredentials = true;
            //using (var client = new HttpClient(handler))
            //{
            //    client.BaseAddress = new Uri(ServerUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    try
            //    {
            //        var response = client.GetAsync("api/Hotels").Result;

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var hotelList =  response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
            //        Hotels = new ObservableCollection<Hotel>(hotelList.ToList());
            //    }

            //    }
            //    catch (Exception ex)
            //    {
            //        new MessageDialog(ex.Message).ShowAsync();
            //    }
            //}
       }

       
            //protected async void messageBox(string msg)
            //{
            //     var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            //     msgDlg.DefaultCommandIndex = 1;
            //     await msgDlg.ShowAsync();
            //}

        private async Task GetHotelsAsync()
        {
            //const string ServerUrl = "http://localhost:50000";
            //HttpClientHandler handler = new HttpClientHandler();
            //handler.UseDefaultCredentials = true;
            //using (var client = new HttpClient(handler))
            //{
            //    client.BaseAddress = new Uri(ServerUrl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    var response = await client.GetAsync("api/Hotels");

            //    if (response.IsSuccessStatusCode)
            //    {
            //       var hotelList = await response.Content.ReadAsAsync<IEnumerable<Hotel>>();
            //       Hotels =  hotelList as ObservableCollection<Hotel>;

            //    }

            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
