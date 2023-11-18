using EysHospitalMIS.Models.DTO;
using EysHospitalMIS.Models.SystemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.BLL.IManager.SystemData
{
    public interface IDepartmentManager
    {
        public void CreateDepartment(Department department);
        public DataBindModel GetAllDepartmentList(int Page = 1, int PerPage = 10);
        public Department GetDepartmentById(int id);
        public void UpdateDepartment(Department department);
        public void DeleteDepartment(int id);
    }
}
