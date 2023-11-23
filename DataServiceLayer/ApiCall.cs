using DataProvider;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
   public class ApiCall
    {
        public static HttpClient Initial()
        {
            ApiConnection ac = new ApiConnection();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string baseurl = "https://localhost:44334/";
            // string baseurl = "http://10.48.1.105:5053/"; 
            //string baseurl = "http://localhost:5051/";
            client.BaseAddress = new Uri(baseurl);
            return client;
        }

        //internal static Task<string> ApiCallWithString(string v1, SelectStoreMaster pm, string v2)
        //{
        //    throw new NotImplementedException();
        //}

        public static async Task<string> ApiCallWithString(string URl, string _GetString, string Action)
        {
            try
            {
                HttpClient client = Initial();
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(_GetString), UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(URl, httpContent);
                if (res.IsSuccessStatusCode)
                {
                    string result = res.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    return "Null";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static async Task<string> ApiCallWithObject(string URl, object _GetObject, string Action)
        {
            try
            {
                HttpClient client = Initial();
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(_GetObject), UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(URl, httpContent);
                if (res.IsSuccessStatusCode)
                {
                    string result = res.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    return "Null";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
