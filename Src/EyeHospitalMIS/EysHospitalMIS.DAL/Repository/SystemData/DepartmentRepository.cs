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

        public DataBindModel GetAllDepartmentList(int Page = 1, int PerPage = 10)
        {
            DataBindModel responseModel = new DataBindModel();
            List<Department> departments = new List<Department>();

            string query = @"EXEC SP_SD_DEPARTMENT_LIST @SEARCH_PARAM, @SORT_EXPRESSION, @START_INDEX, @ROW_COUNT";

            List<param> parameters = new List<param>();
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SEARCH_PARAM", SqlValue = null });
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SORT_EXPRESSION", SqlValue = "ID DESC" });
            parameters.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@START_INDEX", SqlValue = Page });
            parameters.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@ROW_COUNT", SqlValue = PerPage });

            DataTable departmentData = _dbContext.GetDataTable(query, parameters);

            foreach(DataRow row in departmentData.Rows)
            {
                Department department = new Department();
                department.ID = Convert.ToInt32(row["ID"].ToString());
                department.NAME = row["NAME"].ToString();
                department.SHORT_NAME = row["SHORT_NAME"].ToString();
                department.DEPARTMENT_ICON = row["DEPARTMENT_ICON"].ToString();
                department.STATUS = Convert.ToInt32(row["STATUS"].ToString());
                department.TOTAL_COUNT = Convert.ToInt32(row["TOTAL_COUNT"].ToString());
                departments.Add(department);
            }

            int totalCount = departments.FirstOrDefault()?.TOTAL_COUNT ?? 0;
            responseModel.data = departments;
            responseModel.pageSummary = _dbContext.PaginationSummary(totalCount, PerPage, Page);

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

        public Department GetDepartmentById(int id)
        {
            Department department = new Department();
            string query = @"EXEC SP_SD_DEPARTMENT_GET_BY_ID @ID";

            List<param> parameters = new List<param>();
            parameters.Add(new param { SqlDbType=SqlDbType.Int, ParamName = "@ID", SqlValue = id});

            DataSet departmentData = _dbContext.GetDataSet(query, parameters);

            if(departmentData.Tables.Count > 0 && departmentData.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = departmentData.Tables[0].Rows[0];
                department = new Department
                {
                    ID = Convert.ToInt32(dataRow["ID"]),
                    NAME = dataRow["NAME"].ToString(),
                    SHORT_NAME = dataRow["SHORT_NAME"].ToString(),
                    DEPARTMENT_ICON = dataRow["DEPARTMENT_ICON"].ToString(),
                    STATUS = Convert.ToInt32(dataRow["STATUS"])
                };
            }
            return department;
        }

        public void UpdateDepartment(Department department)
        {
            string query = @"EXEC SP_SD_DEPARTMENT_UPDATE @ID, @NAME, @SHORT_NAME, @STATUS";

            List<param> parameters = new List<param>();
            parameters.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@ID", SqlValue = department.ID });
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@NAME", SqlValue = department.NAME });
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SHORT_NAME", SqlValue = department.SHORT_NAME });
            parameters.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "STATUS", SqlValue = department.STATUS });

            _dbContext.ExecuteQuery(query, parameters);
        }

        public void DeleteDepartment(int id)
        {
            string query = @"EXEC SP_SD_DEPARTMENT_DELETE @ID";

            List<param> parameters = new List<param>();
            parameters.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@ID", SqlValue = id });
            _dbContext.ExecuteQuery(query,parameters);
        }
    }
}
