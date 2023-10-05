using EysHospitalMIS.BLL.IManager.SystemData;
using EysHospitalMIS.DAL.IRepository.SystemData;
using EysHospitalMIS.Models.DTO;
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

        public async Task<DataBindModel> GetAllDepartment(int Page = 1, int PerPage = 10)
        {
            try
            {
                return await iDepartmentRepository.GetAllDepartment(Page, PerPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataBindModel GetAllDepartmentList(int Page = 1, int PerPage = 10)
        {
            try
            {
                return iDepartmentRepository.GetAllDepartmentList(Page, PerPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
