using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelsApp.Util;

namespace HotelsApp.Model
{
    class HotelCatalogSingleton
    {
        private static HotelCatalogSingleton _instance;

        public static HotelCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HotelCatalogSingleton();
                }
                return _instance;
            }
        }

        private ObservableCollection<Hotel> _hotels;        
        public ObservableCollection<Hotel> Hotels
        {
            get { return _hotels; }
            set { _hotels = value; }
        }

        public HotelCatalogSingleton()
        {
            Hotels = new ObservableCollection<Hotel>(new PersistenceFacade().GetHotels());
        }

    }
}
