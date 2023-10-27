using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.DTO
{
    public  class PageSummary
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public int CurrentPage { get; set; }
        public string RedirectUrlMethod { get; set; } = "Index";
        public int TotalNumberOfRecord { get; set; }
    }
}
