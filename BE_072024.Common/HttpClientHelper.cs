using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BE_072024.Common
{
    public class HttpClientHelper
    {
        public static async Task<string> SendGet(string baseurl, string api_name)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                HttpResponseMessage response = await client.GetAsync(api_name);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return string.Empty;
            }
        }

        public static async Task<string> HttpSenPost(string baseUrl, string api, string jsonData)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    StringContent queryString = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                    var url = baseUrl + api;
                    HttpResponseMessage response = await client.PostAsync(new Uri(url), queryString);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<string> HttpSenPostWithToken(string baseUrl, string api, string jsonData, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    StringContent queryString = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                    var url = baseUrl + api;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
                    HttpResponseMessage response = await client.PostAsync(new Uri(url), queryString);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
