using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using CESParcelDeliverySystem.DTOs;


namespace CESParcelDeliverySystem.Connectors
{
    public class EITCConnector
    {
        public static async void ExecuteImplementation()
        {

            string baseUrl = "http://pokeapi.co/api/v2/pokemon/";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {

                                Console.WriteLine("data------------{0}", data);
                            }
                            else
                            {

                                // Do errorhandling
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }
    }
}
