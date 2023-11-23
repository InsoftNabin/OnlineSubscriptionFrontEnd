using DataProvider;
using DataService;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    public class SLLogin
    {
        public async Task<SelectLoginInfo> GetLoginInfo(LoginValidator login)
        {
            try
            {
                string Data = await ApiCall.ApiCallWithObject("ValidateUser/ValidateUser", login, "Post");
                SelectLoginInfo li = JsonConvert.DeserializeObject<SelectLoginInfo>(Data);
                return li;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
