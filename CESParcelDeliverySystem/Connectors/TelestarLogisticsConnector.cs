using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using CESParcelDeliverySystem.DTOs;
using Microsoft.IdentityModel.Tokens;


namespace CESParcelDeliverySystem.Connectors
{
    public class TelestarLogisticsConnector
    {

        public int addNum()
        {
            return 21;
        }

        public async void FetchData()
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