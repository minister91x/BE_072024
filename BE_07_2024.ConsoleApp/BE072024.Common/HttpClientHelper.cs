using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.Common
{
    public static class HttpClientHelper
    {
        public static async Task<string> SendGet(string baseURL, string api)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method
                    HttpResponseMessage response = await client.GetAsync(api);
                    if (response.IsSuccessStatusCode)
                    {

                        var data = await response.Content.ReadAsStringAsync();
                        var list = new List<AcccountDEMO>();
                        if (!string.IsNullOrEmpty(data))
                        {
                            // convert từ json sang class
                            list = JsonConvert.DeserializeObject<List<AcccountDEMO>>(data);
                        }

                        if (list != null && list.Count() > 0)
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine("ID :  {0}", item.ID);
                                Console.WriteLine("FullName :  {0}", item.FullName);
                                Console.WriteLine("UserName :  {0}", item.UserName);
                            }
                        }
                        return data;
                    }

                    return string.Empty;

                }

                return string.Empty;
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }
    }

    public class AcccountDEMO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
