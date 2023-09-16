using EysHospitalMIS.BLL.IManager.SystemData;
using EysHospitalMIS.Models.SystemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.BLL.Manager.SystemData
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentManager iDepartmentManager;

        public void CreateNewDepartment(Department department)
        {

            try
            {
                iDepartmentManager.CreateNewDepartment(department);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
