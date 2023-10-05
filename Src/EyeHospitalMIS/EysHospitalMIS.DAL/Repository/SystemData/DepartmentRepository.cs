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

        public async Task<DataBindModel> GetAllDepartment(int Page = 1, int PerPage = 10)
        {
            try
            {
                DataBindModel responseModel = new DataBindModel();
                List<Department> departments = new List<Department>();

                string query = @"EXEC SP_SD_DEPARTMENT_LIST @SEARCH_PARAM, @SORT_EXPRESSION, @START_INDEX, @ROW_COUNT";

                List<param> parameters = new List<param>();
                parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SEARCH_PARAM", SqlValue = null });
                parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SORT_EXPRESSION", SqlValue = "ID ASC" });
                parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@START_INDEX", SqlValue = Page });
                parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@ROW_COUNT", SqlValue = PerPage });

                using (DbDataReader reader = await _dbContext.ExecuteReaderAsync(query, parameters))
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            Department department = new Department();
                            department.NAME = reader["NAME"].ToString();
                            department.SHORT_NAME = reader["SHORT_NAME"].ToString();
                            department.DEPARTMENT_ICON = reader["DEPARTMENT_ICON"].ToString();
                            department.STATUS = Convert.ToInt32(reader["STAUTS"]);

                            departments.Add(department);
                        }
                    }
                    else
                    {
                        // Handle the case when there are no rows returned.
                        // You can log a message or perform other actions as needed.
                    }
                }

                responseModel.data = departments;
                return responseModel;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return null;
            }
        }


        public DataBindModel GetAllDepartmentList(int Page, int PerPage = 10)
        {
            try
            {
                DataBindModel responseModel = new DataBindModel();
                List<Department> departments = new List<Department>();

                string query = @"EXEC SP_SD_DEPARTMENT_LIST @SEARCH_PARAM, @SORT_EXPRESSION, @START_INDEX, @ROW_COUNT";

                List<param> parameters = new List<param>();
                parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SEARCH_PARAM", SqlValue = null });
                parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@SORT_EXPRESSION", SqlValue = "ID ASC" });
                parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@START_INDEX", SqlValue = Page });
                parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@ROW_COUNT", SqlValue = PerPage });

                using (DbDataReader reader = _dbContext.ExecuteReader(query, parameters))
                {
                    while (reader.Read())
                    {
                        Department department = new Department();

                        department.NAME = reader.GetString(1);
                        department.SHORT_NAME = reader.GetString(2);
                        department.DEPARTMENT_ICON = reader.GetString(3);
                        department.STATUS = Convert.ToInt32(reader["STAUTS"]);

                        departments.Add(department);
                    }
                }

                responseModel.data = departments;
                responseModel.pageSummary = null;

                return responseModel;
            }
            catch(Exception ex)
            {
                return null;
            }
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
