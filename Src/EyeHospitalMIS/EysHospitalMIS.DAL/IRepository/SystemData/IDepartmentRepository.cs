using EysHospitalMIS.Models.DTO;
using EysHospitalMIS.Models.SystemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.DAL.IRepository.SystemData
{
    public interface IDepartmentRepository
    {
        public Task<DataBindModel> GetAllDepartment(int Page = 1, int PerPage = 10);
        public DataBindModel GetAllDepartmentList(int Page = 1, int PerPage = 10);
        public void CreateDepartment(Department department);
    }
}
