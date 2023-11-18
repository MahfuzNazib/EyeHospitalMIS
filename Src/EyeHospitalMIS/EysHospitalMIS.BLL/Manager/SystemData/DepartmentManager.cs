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

        public Department GetDepartmentById(int id)
        {
            try
            {
                return iDepartmentRepository.GetDepartmentById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UpdateDepartment(Department department)
        {
            iDepartmentRepository.UpdateDepartment(department);
        }

        public void DeleteDepartment(int id)
        {
            iDepartmentRepository.DeleteDepartment(id);
        }
    }
}
