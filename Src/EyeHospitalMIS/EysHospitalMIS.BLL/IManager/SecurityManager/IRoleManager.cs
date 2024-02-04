using EysHospitalMIS.Models.DTO;
using EysHospitalMIS.Models.SecurityManager.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.BLL.IManager.SecurityManager
{
    public interface IRoleManager
    {
        DataBindModel GetAllRoles(int Page = 1, int PerPage = 10);
        List<RolePermission> GetAllRolePermission();
        void SaveNewRolePermission(RolePermissionRequest rolePermissionRequest);
    }
}
