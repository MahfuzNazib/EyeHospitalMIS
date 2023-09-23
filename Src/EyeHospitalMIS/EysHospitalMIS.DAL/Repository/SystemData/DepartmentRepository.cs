using EysHospitalMIS.DAL.Data;
using EysHospitalMIS.DAL.IRepository.SystemData;
using EysHospitalMIS.Models.SystemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EysHospitalMIS.Models.DTO;

namespace EysHospitalMIS.DAL.Repository.SystemData
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContext _dbContext;

        public DepartmentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DataBindModel GetAllDepartment()
        {
            DataBindModel responseModel = new DataBindModel();

            string query = "EXEC SP_SD_DEPARTMENT_LIST";
        }

        public void CreateDepartment(Department department)
        {
            string query = @"EXEC SP_SD_CREATE_DEPARTMENT @NAME, @SHORT_NAME, @DEPARTMENT_ICON, @STATUS";

            List<param> parameters = new List<param>();
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@NAME", SqlValue = department.NAME });
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SHORT_NAME", SqlValue = department.SHORT_NAME });
            parameters.Add(new param { SqlDbType = SqlDbType.Text, ParamName = "@DEPARTMENT_ICON", SqlValue = department.DEPARTMENT_ICON });
            parameters.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@STATUS", SqlValue = department.STATUS });

            _dbContext.ExecuteQuery(query, parameters);
        }
    }
}
