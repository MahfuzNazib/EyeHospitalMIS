using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.SecurityManager.Role
{
    public class RolePermissionRequest
    {
        public string ROLE_NAME { get; set; } = string.Empty;
        public string DESCRIPTION { get; set; } = string.Empty;
        public int BRANCH_ID { get; set; }
        public int[] PERMISSION_ID { get; set; }
        public int IS_ACTIVE { get; set; } = 1;
    }
}
