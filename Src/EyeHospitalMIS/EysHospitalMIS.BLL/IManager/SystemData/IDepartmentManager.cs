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
    }
}
