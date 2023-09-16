using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.DAL.Data
{
    public class param
    {
        public SqlDbType SqlDbType { get; set; }
        public string? ParamName { get; set; }
        public dynamic? SqlValue { get; set; }
    }
}
