using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WSRestHotels;

namespace WSRestHotelsTestConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            const string ServerUrl = "http://localhost:50000";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Console.WriteLine("api/Hotels");
                    var response0 = client.GetAsync("api/Hotels").Result;
                    if (response0.IsSuccessStatusCode)
                    {
                        IEnumerable<Hotel> hotelRoomList = response0.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        foreach (Hotel hotelRoom in hotelRoomList)
                        {
                            Console.WriteLine(hotelRoom);
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("api/guestlists");
                    var response1 = client.GetAsync("api/guestlists").Result;
                    Console.WriteLine(response1);
                    if (response1.IsSuccessStatusCode)
                    {
                        IEnumerable<GuestList> guestList = response1.Content.ReadAsAsync<IEnumerable<GuestList>>().Result;
                        foreach (var guest in guestList)
                        {
                            Console.WriteLine(guest);
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("api/guestlists/2011-02-05");
                    var response2 = client.GetAsync("api/guestlists/2011-02-05").Result;
                    if (response2.IsSuccessStatusCode)
                    {
                        IEnumerable<GuestListDTO> guestList = response2.Content.ReadAsAsync<IEnumerable<GuestListDTO>>().Result;
                        foreach (var guest in guestList)
                        {
                            Console.WriteLine(guest);
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("api/bookings");
                    var response3 = client.GetAsync("api/bookings").Result;
                    if (response3.IsSuccessStatusCode)
                    {
                        IEnumerable<Booking> bookings = response3.Content.ReadAsAsync<IEnumerable<Booking>>().Result;
                        foreach (var booking in bookings)
                        {
                            Console.WriteLine(booking);
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("api/Test");
                    var response4 = client.GetAsync("api/Test").Result;
                    if (response4.IsSuccessStatusCode)
                    {
                        var foo = response4.Content.ReadAsAsync<IEnumerable<String>>().Result;
                        foreach (var text in foo)
                        {
                            Console.WriteLine(text);
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("api/Test/Foo2");
                    var response5 = client.GetAsync("api/Test/Foo2").Result;
                    if (response5.IsSuccessStatusCode)
                    {
                        var foo = response5.Content.ReadAsAsync<IEnumerable<String>>().Result;
                        foreach (var text in foo)
                        {
                            Console.WriteLine(text);
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("api/Test/Foo3");
                    var response6 = client.GetAsync("api/Test/Foo3").Result;
                    if (response6.IsSuccessStatusCode)
                    {
                        var foo = response6.Content.ReadAsAsync<IEnumerable<String>>().Result;
                        foreach (var text in foo)
                        {
                            Console.WriteLine(text);
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("api/Test/1");
                    var response7 = client.GetAsync("api/Test/1").Result;
                    if (response7.IsSuccessStatusCode)
                    {
                        var foo = response7.Content.ReadAsAsync<String>().Result;
                        
                            Console.WriteLine(foo);
                        
                    }
                    Console.WriteLine();
                }
                catch (Exception)
                {

                    throw;
                }

               
            }
        }
    }
}
