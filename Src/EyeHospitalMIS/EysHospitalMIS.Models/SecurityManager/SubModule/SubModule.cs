using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.SecurityManager.SubModule
{
    public class SubModule
    {
        public int ID { get; set; }
        public int MODULE_ID { get; set; }
        public string NAME { get; set; }
        public string SUBMODULE_KEY { get; set; }
        public string ROUTE { get; set; }
        public int POSITION { get; set; }
        public int IS_ACTIVE { get; set; }
    }
}
