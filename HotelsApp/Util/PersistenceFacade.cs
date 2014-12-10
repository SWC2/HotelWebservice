using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using HotelsApp.Handler;
using HotelsApp.Model;
using Newtonsoft.Json;

namespace HotelsApp.Util
{
    class PersistenceFacade
    {
        const string ServerUrl = "http://localhost:30006";
        const string LoginServerUrl = "http://localhost:55556";
        HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        public Login ValidateLogin(string username, string password)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(LoginServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string url = "api/Profiles/" + username + "/" + password;
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var login = response.Content.ReadAsAsync<Login>().Result;
                        return login;
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
            
        }


        public List<Hotel> GetHotels()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotelList = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        return hotelList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public void DeleteHotel(int hotelNo)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.DeleteAsync("api/Hotels/" + hotelNo).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        //Notice: Install the NuGet Packages: Json.Net from Newtonsoft
        public void SaveHotel(Hotel hotel)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    //string postBody = JsonConvert.SerializeObject(hotel);
                    //var response = client.PostAsync("api/Hotels",new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                    var response = client.PostAsJsonAsync("api/hotels", hotel).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }

        }

        public async void SerializeHotelsAsJsonFile(ObservableCollection<Hotel> hotels)
        {
            string fileName = "HotelsAsJson.dat";
            string HotelsJsonString = JsonConvert.SerializeObject(hotels);
          
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting); 
            await FileIO.WriteTextAsync(localFile, HotelsJsonString);

        }

        public async Task<ObservableCollection<Hotel>> DeSerializeHotelsAsJsonFile()
        {
            string fileName = "HotelsAsJson.dat";        
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            string HotelsJsonString = await FileIO.ReadTextAsync(localFile);
            ObservableCollection<Hotel> hotels = (ObservableCollection<Hotel>)JsonConvert.DeserializeObject(HotelsJsonString, typeof(ObservableCollection<Hotel>));
            return hotels;
        }

        public List<HotelRoom> GetRooms(Hotel hotel)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/HotelRooms/" + hotel.Hotel_No).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotelroomList = response.Content.ReadAsAsync<IEnumerable<HotelRoom>>().Result;
                        return hotelroomList.ToList();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
    }
}
