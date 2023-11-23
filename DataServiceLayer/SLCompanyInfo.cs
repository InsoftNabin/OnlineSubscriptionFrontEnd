using DataService;
using System;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    public class SLCompanyInfo
    {
        public async Task<string> GetCompanyData(string Initial)
        {
            try
            {
                string Data = await ApiCall.ApiCallWithString("CompanyInformation/GetCompanyData", Initial, "Post");
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetCompanyDataByTokenNo(string Token)
        {
            try
            {
                string Data = await ApiCall.ApiCallWithString("CompanyInformation/GetCompanyDataByTokenNo", Token, "Post");
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetReportForDashboard(string Token)
        {
            try
            {
                string Data = await ApiCall.ApiCallWithString("CompanyInformation/GetReportForDashboard", Token, "Post");
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
