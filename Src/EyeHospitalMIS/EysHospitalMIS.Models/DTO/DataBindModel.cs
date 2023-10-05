using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.DTO
{
    public class DataBindModel
    {
        public dynamic data { get; set; }
        public PageSummary pageSummary { get; set; }

        public static implicit operator SqlDataReader(DataBindModel v)
        {
            throw new NotImplementedException();
        }
    }
}
