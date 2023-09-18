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
        public void CreateDepartment(Department department);
    }
}
