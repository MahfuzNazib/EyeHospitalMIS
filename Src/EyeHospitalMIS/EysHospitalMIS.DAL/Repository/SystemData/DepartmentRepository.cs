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
using System.Data.SqlClient;
using System.Data.Common;

namespace EysHospitalMIS.DAL.Repository.SystemData
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContext _dbContext;

        public DepartmentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DataBindModel GetAllDepartmentList(int page = 1, int perPage = 10)
        {
            DataBindModel responseModel = new DataBindModel();
            List<Department> departments = new List<Department>();

            string query = @"EXEC SP_SD_DEPARTMENT_LIST @SEARCH_PARAM, @SORT_EXPRESSION, @START_INDEX, @ROW_COUNT";

            List<param> parameters = new List<param>();
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SEARCH_PARAM", SqlValue = null });
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SORT_EXPRESSION", SqlValue = "ID ASC" });
            parameters.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@START_INDEX", SqlValue = page });
            parameters.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@ROW_COUNT", SqlValue = perPage });

            DataTable departmentData = _dbContext.GetDataTable(query, parameters);

            foreach(DataRow row in departmentData.Rows)
            {
                Department department = new Department();
                department.NAME = row["NAME"].ToString();
                department.SHORT_NAME = row["SHORT_NAME"].ToString();
                department.DEPARTMENT_ICON = row["DEPARTMENT_ICON"].ToString();
                department.STATUS = Convert.ToInt32(row["STATUS"].ToString());
                department.TOTAL_COUNT = Convert.ToInt32(row["TOTAL_COUNT"].ToString());
                departments.Add(department);
            }

            int totalCount = departments.FirstOrDefault()?.TOTAL_COUNT ?? 0;
            responseModel.data = departments;
            responseModel.pageSummary = _dbContext.PaginationSummary(totalCount, perPage, page);

            return responseModel;
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
