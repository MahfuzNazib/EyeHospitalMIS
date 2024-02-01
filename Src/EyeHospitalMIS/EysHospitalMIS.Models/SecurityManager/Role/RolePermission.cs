using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.SecurityManager.Role
{
    public class RolePermission
    {
        public int ID { get; set; }
        public string DISPLAY_NAME { get; set; } = string.Empty;
        public string PERMISSION_KEY { get; set; } = string.Empty;
        public int MODULE_ID { get; set; }
        public int? IS_TOPBAR { get; set; }
        public int? PARENT_ID { get; set; }
    }
}
