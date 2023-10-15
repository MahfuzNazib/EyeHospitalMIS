using EysHospitalMIS.Models.DTO;

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
    }
}
