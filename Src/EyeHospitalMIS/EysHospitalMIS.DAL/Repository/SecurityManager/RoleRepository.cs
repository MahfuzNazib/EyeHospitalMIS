using EysHospitalMIS.DAL.Data;
using EysHospitalMIS.DAL.IRepository.SecurityManager;
using EysHospitalMIS.Models.DTO;
using EysHospitalMIS.Models.SecurityManager.Role;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.DAL.Repository.SecurityManager
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DataBindModel GetAllRoles(int Page = 1, int PerPage = 10)
        {
            DataBindModel responseModel = new DataBindModel();
            List<Role> roles = new List<Role>();

            string query = @"EXEC SP_SM_ROLE_LIST @SEARCH_PARAM, @SORT_EXPRESSION, @START_INDEX, @ROW_COUNT";

            List<param> parameters = new List<param>();
            parameters.Add(new param{ SqlDbType = SqlDbType.VarChar, ParamName = "@SEARCH_PARAM", SqlValue = null});
            parameters.Add(new param{ SqlDbType = SqlDbType.VarChar, ParamName = "@SORT_EXPRESSION", SqlValue = "ID DESC" });
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@START_INDEX", SqlValue = Page });
            parameters.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@ROW_COUNT", SqlValue = PerPage });

            DataTable roleData = _dbContext.GetDataTable(query, parameters);

            foreach(DataRow row in roleData.Rows)
            {
                Role role = new Role();
                role.ID = Convert.ToInt32(row["ID"]);
                role.NAME = row["NAME"].ToString();
                role.IS_ACTIVE = Convert.ToInt32(row["IS_ACTIVE"]);
                role.TOTAL_COUNT = Convert.ToInt32(row["TOTAL_COUNT"]);
                roles.Add(role);
            }

            int totalCount = roles.FirstOrDefault()?.TOTAL_COUNT ?? 0;
            responseModel.data = roles;
            responseModel.pageSummary = _dbContext.PaginationSummary(totalCount, PerPage, Page);

            return responseModel;
        }

        public List<RolePermission> GetAllRolePermission()
        {
            List<RolePermission> permissions = new List<RolePermission>();

            string query = @"EXEC SP_SM_PERMISSION_LIST";
            DataTable permissionData = _dbContext.GetDataTable(query);

            foreach(DataRow row in permissionData.Rows)
            {
                RolePermission permission = new RolePermission();
                permission.ID = Convert.ToInt32(row["ID"]);
                permission.DISPLAY_NAME = row["DISPLAY_NAME"].ToString();
                permission.PERMISSION_KEY = row["PERMISSION_KEY"].ToString();
                permission.MODULE_ID = Convert.ToInt32(row["MODULE_ID"]);
                // Check for DBNull before converting to int
                permission.IS_TOPBAR = row["IS_TOPBAR"] != DBNull.Value ? Convert.ToInt32(row["IS_TOPBAR"]) : null;
                permission.PARENT_ID = row["PARENT_ID"] != DBNull.Value ? Convert.ToInt32(row["PARENT_ID"]) : null;

                permissions.Add(permission);
            }

            return permissions;
        }

        public void SaveNewRolePermission(RolePermissionRequest rolePermissionRequest)
        {
            int roleId = SaveNewRole(rolePermissionRequest);
            SavePermissionData(rolePermissionRequest, roleId);
        }

        private int SaveNewRole(RolePermissionRequest rolePermissionRequest)
        {
            int insertedRoleId;
            string query = @"SP_SM_ROLE_CREATE @NAME, @IS_ACTIVE, @DESCRIPTION, @BRANCH_ID";
            List<param> param = new List<param>();
            param.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@NAME", SqlValue = rolePermissionRequest.ROLE_NAME });
            param.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@IS_ACTIVE", SqlValue = rolePermissionRequest.IS_ACTIVE });
            param.Add(new param { SqlDbType = SqlDbType.VarChar, ParamName = "@DESCRIPTION", SqlValue = rolePermissionRequest.DESCRIPTION });
            param.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@BRANCH_ID", SqlValue = rolePermissionRequest.BRANCH_ID });

            insertedRoleId = _dbContext.ExecuteQueryWithId(query, param);
            return insertedRoleId;
        }

        private void SavePermissionData(RolePermissionRequest rolePermissionRequest, int roleId)
        {
            
            if (rolePermissionRequest.PERMISSION_ID != null)
            {
                foreach (int permissionId in rolePermissionRequest.PERMISSION_ID)
                {
                    string query = @"SP_SM_ROLE_PREMISSION_CREATE @ROLE_ID, @PERMISSION_ID, @STATUS";
                    List<param> param = new List<param>();

                    param.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@ROLE_ID", SqlValue = roleId });
                    param.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@PERMISSION_ID", SqlValue = permissionId });
                    param.Add(new param { SqlDbType = SqlDbType.Int, ParamName = "@STATUS", SqlValue = rolePermissionRequest.IS_ACTIVE });
                    _dbContext.ExecuteQuery(query, param);
                }
            }
        }
    }
}
