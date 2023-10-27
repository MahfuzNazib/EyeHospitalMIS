using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.DTO
{
    public class GridFilter
    {
        public string SearchKey { get; set; } = string.Empty;
        public int NumberOfItemPerPage { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
