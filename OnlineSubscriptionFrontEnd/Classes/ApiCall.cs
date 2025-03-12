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


        public static HttpClient Initial()
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(10);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string baseurl = Startup.baseapiurl;
            client.BaseAddress = new Uri(baseurl);
            return client;
        }



        public static HttpClient FonePayInitial()
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(10);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           string baseurl = "https://qr.intradeplus.com/";
           // string baseurl = "http://202.51.74.37:5354/";
           // string baseurl = "http://localhost:2039/";
            client.BaseAddress = new Uri(baseurl);
            return client;
        }




        public static async Task<string> ApiCallWithOutObject(string URl, string Action)
        {
            try
            {
                HttpClient client = Initial();
                client.DefaultRequestHeaders.Accept.Clear();
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage res = new HttpResponseMessage();
                if (Action == "Post")
                {
                    res = await client.PostAsync(URl, httpContent);
                }
                else
                {
                    res = await client.GetAsync(URl);
                }

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



        //public static async Task<string> ApiCallWithString(string URl, string _GetString, string Action)
        //{
        //    try
        //    {
        //        HttpClient client = Initial();
        //        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(_GetString), UTF8Encoding.UTF8, "application/json");
        //        HttpResponseMessage res = await client.PostAsync(URl, httpContent);
        //        if (res.IsSuccessStatusCode) 


        //        {
        //            string result = await res.Content.ReadAsStringAsync();
        //            return result;
        //        }
        //        else
        //        {
        //            return "Null";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string Exception = ex.ToString(); var ExceptionSubstring = Exception.Substring(0, 1500); return RedirectToAction("Exception", "Helper", new { ExceptionString = ExceptionSubstring });
        //    }
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
                    string result = await res.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    return "Null";
                }
            }
            catch (Exception ex)
            {
                string exceptionString = ex.ToString();
                var exceptionSubstring = exceptionString.Length > 1500 ? exceptionString.Substring(0, 1500) : exceptionString;
                return RedirectToAction("Exception", "Helper", new { ExceptionString = exceptionSubstring });
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

        //public static async Task<string> ApiCallWithObject(string URl, object _GetObject, string Action)
        //{
        //    try
        //    {
        //        HttpClient client = Initial();
        //        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(_GetObject), UTF8Encoding.UTF8, "application/json");
               
        //        //check
        //        httpContent.Headers.ContentLength = httpContent.ReadAsByteArrayAsync().Result.Length;

        //        HttpResponseMessage res = await client.PostAsync(URl, httpContent);
        //        if (res.IsSuccessStatusCode)
        //        {
        //            string result = await res.Content.ReadAsStringAsync();
        //            return result;
        //        }
        //        else
        //        {
        //            return "Null";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string Exception = ex.ToString(); var ExceptionSubstring = Exception.Substring(0, 1500); return RedirectToAction("Exception", "Helper", new { ExceptionString = ExceptionSubstring });
        //    }
        //}

        public static async Task<string> ApiCallWithObject(string URl, object _GetObject, string Action)
        {
            try
            {
                HttpClient client = Initial();
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(_GetObject), UTF8Encoding.UTF8, "application/json");

              
                var byteArray = await httpContent.ReadAsByteArrayAsync();
                if (byteArray != null)
                {
                    httpContent.Headers.ContentLength = byteArray.Length;
                }
                else
                {
                    httpContent.Headers.ContentLength = 0; 
                }

                HttpResponseMessage res = await client.PostAsync(URl, httpContent);

                if (res.IsSuccessStatusCode)
                {
                    string result = await res.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    return "Null";
                }
            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                var ExceptionSubstring = Exception.Length > 1500 ? Exception.Substring(0, 1500) : Exception;
                return RedirectToAction("Exception", "Helper", new { ExceptionString = ExceptionSubstring });
            }
        }


        public static async Task<string> FonePayApiCallWithObject(string URl, object _GetObject, string Action)
        {
            try
            {
                HttpClient client = FonePayInitial();
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

    }
}
