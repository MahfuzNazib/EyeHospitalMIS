using EysHospitalMIS.BLL.IManager.SecurityManager;
using EysHospitalMIS.DAL.IRepository.SecurityManager;
using EysHospitalMIS.Models.DTO;
using EysHospitalMIS.Models.SecurityManager.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.BLL.Manager.SecurityManager
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepository iRoleRepository;

        public RoleManager(IRoleRepository iRoleRepository)
        {
            this.iRoleRepository = iRoleRepository;
        }

        public DataBindModel GetAllRoles(int Page = 1, int PerPage = 10)
        {
            return iRoleRepository.GetAllRoles(Page, PerPage);
        }
        public List<RolePermission> GetAllRolePermission()
        {
            return iRoleRepository.GetAllRolePermission();
        }

        public void SaveNewRolePermission(RolePermissionRequest rolePermissionRequest)
        {
            iRoleRepository.SaveNewRolePermission(rolePermissionRequest);
        }
    }
}
