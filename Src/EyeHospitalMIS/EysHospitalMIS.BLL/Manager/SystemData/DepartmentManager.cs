using EysHospitalMIS.BLL.IManager.SystemData;
using EysHospitalMIS.DAL.IRepository.SystemData;
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
        private readonly IDepartmentRepository iDepartmentRepository;

        public DepartmentManager(IDepartmentRepository iDepartmentRepository)
        {
            this.iDepartmentRepository = iDepartmentRepository;
        }

        public void CreateDepartment(Department department)
        {
            try
            {
                iDepartmentRepository.CreateDepartment(department);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
