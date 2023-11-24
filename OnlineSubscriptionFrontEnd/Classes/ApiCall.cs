using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSubscriptionFrontEnd.Classes
{
    public static class ApiCall
    {
        public static readonly TimeSpan InfiniteTimeSpan;
        public static HttpClient Initial()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string baseurl = Startup.baseapiurl;
            client.BaseAddress = new Uri(baseurl);
            return client;
        }

        public static HttpClient GPSInitial()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string baseurl = Startup.baseapiurl;
            client.BaseAddress = new Uri(baseurl);
            return client;
        }

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
                string Exception = ex.ToString(); var ExceptionSubstring = Exception.Substring(0, 1500); return RedirectToAction("Exception", "Helper", new { ExceptionString = ExceptionSubstring });
            }
        }

        internal static Task<string> ApiCallWithString(string v, string tokenNo)
        {
            throw new NotImplementedException();
        }

        private static string RedirectToAction(string v1, string v2, object p)
        {
            throw new NotImplementedException();
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
                string Exception = ex.ToString(); var ExceptionSubstring = Exception.Substring(0, 1500); return RedirectToAction("Exception", "Helper", new { ExceptionString = ExceptionSubstring });
            }
        }

        public static string RemoveEncoding(string encodedJson)
        {
            var sb = new StringBuilder(encodedJson);
            sb.Replace("\\", string.Empty);
            sb.Replace("\"[", string.Empty);
            sb.Replace("]\"", string.Empty);
            return sb.ToString();
        }

        public static string RemoveEncodingOnJsonArray(string encodedJson)
        {
            var sb = new StringBuilder(encodedJson);
            sb.Replace("\\", string.Empty);
            sb.Replace("\"[", "[");
            sb.Replace("]\"", "]");
            return sb.ToString();
        }

        public static string RemoveArray(string encodedJson)
        {
            var sb = new StringBuilder(encodedJson);
            sb.Replace("[", string.Empty);
            sb.Replace("]", string.Empty);
            return sb.ToString();
        }

        public static HttpContent GetHttpContentForObject(object httpcontent)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(httpcontent), UTF8Encoding.UTF8, "application/json");
            return httpContent;
        }

        public static HttpContent GetHttpContentForString(string httpcontent)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(httpcontent), UTF8Encoding.UTF8, "application/json");
            return httpContent;
        }

        public static async Task<string> ApiCallForGPSAuth(string URl, object _GetObject, string Action)
        {
            try
            {
                HttpClient client = GPSInitial();
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
                string Exception = ex.ToString(); var ExceptionSubstring = Exception.Substring(0, 1500); return RedirectToAction("Exception", "Helper", new { ExceptionString = ExceptionSubstring });
            }
        }

        public static async Task<string> ApiCallForGPS(string URl, string AccessToken, object _GetObject, string Action)
        {
            try
            {
                HttpClient client = GPSInitial();
                client.DefaultRequestHeaders.Add("AccessToken", AccessToken);
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(_GetObject), UTF8Encoding.UTF8, "application/json");
                if (Action.ToUpper() == "POST")
                {
                    HttpResponseMessage res = await client.PostAsync(URl, httpContent).ConfigureAwait(false);
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
                else if (Action.ToUpper() == "GET")
                {
                    var json = JsonConvert.SerializeObject(_GetObject);
                    var query = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                    var res = await client.GetAsync(QueryHelpers.AddQueryString(URl, query)).ConfigureAwait(false);
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
                else
                {
                    return "Null";
                }

            }
            catch (Exception ex)
            {
                string Exception = ex.ToString(); var ExceptionSubstring = Exception.Substring(0, 1500); return RedirectToAction("Exception", "Helper", new { ExceptionString = ExceptionSubstring });
            }
        }
    }
}
