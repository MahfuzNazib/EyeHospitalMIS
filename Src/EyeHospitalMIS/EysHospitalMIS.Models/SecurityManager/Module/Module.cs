using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.SecurityManager.Module
{
    public class Module
    {
        public int MODULE_ID { get; set; }
        public string MODULE_NAME { get; set; }
        public string MODULE_KEY { get; set; }
        public int POSITION { get; set; }
        public string ICON { get; set; }
        public string IS_ACTIVE { get; set; }
    }
}
