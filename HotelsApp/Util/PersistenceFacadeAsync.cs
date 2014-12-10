using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelsApp.Model;
using Newtonsoft.Json;

namespace HotelsApp.Util
{
    class PersistenceFacadeAsync
    {
        const string ServerUrl = "http://localhost:30006";
        const string LoginServerUrl = "http://localhost:55556";

        HttpClientHandler handler;

        public PersistenceFacadeAsync()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }


        public  IEnumerable<Hotel> GetHotels()
        {
            var task = GetHotelsAsync();
            task.Wait();
            return task.Result;
        } 

        public async Task<IEnumerable<Hotel>> GetHotelsAsync()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.GetAsync("api/Hotels");

                    if (response.IsSuccessStatusCode)
                    {
                        var hotelList = await response.Content.ReadAsAsync<IEnumerable<Hotel>>();
                        return hotelList;
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
                    string postBody = JsonConvert.SerializeObject(hotel);

                    var response = client.PostAsync("api/Hotels",new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            
            }
            
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
    }
}
