using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.SecurityManager.Role
{
    public class Role
    {
        public int ID { get; set; }
        public string NAME { get; set; } = string.Empty;
        public int IS_ACTIVE { get; set; }
        public int TOTAL_COUNT { get; set; }
    }
}
