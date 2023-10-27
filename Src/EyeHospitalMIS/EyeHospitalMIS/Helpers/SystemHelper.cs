using EysHospitalMIS.Models.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EyeHospitalMIS.Helpers
{
    public static class SystemHelper
    {
        public static PageSummary PaginationSummary(int totalCount, int perPage, int page)
        {
            decimal lastPage = (decimal) totalCount / perPage;

            PageSummary pageSummary = new()
            {
                Page = page,
                PerPage = perPage,
                FirstPage = 1,
                LastPage = (int)Math.Ceiling(lastPage)
            };
            
            return pageSummary;
        }


        public static (string, string, string) FormDataSubmitResponse(ITempDataDictionary tempData, string tempDataResponseStatus, string tempDataMessage, string tempDataResponseType)
        {
            string responseStatus = tempData[tempDataResponseStatus] as string ?? "Error";
            string responseMessage = tempData[tempDataMessage] as string ?? "Something Went Wrong. Please Contact System Administator";
            string responseType = tempData[tempDataResponseType] as string ?? "Error";

            return (responseStatus, responseMessage, responseStatus);
        }
    }
}
