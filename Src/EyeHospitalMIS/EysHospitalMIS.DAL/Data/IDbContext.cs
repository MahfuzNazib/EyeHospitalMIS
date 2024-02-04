using EysHospitalMIS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.DAL.Data
{
    public interface IDbContext
    {
        public void ExecuteQuery(string query, List<param> @params);
        public int ExecuteQueryWithId(string query, List<param> @params);
        public void MultiTableExecuteQuery(string firstQuery, List<param> @firstParams, string secondQuery, List<param> @secondParams, string foreignKeyName);
        public DataTable GetDataTable(string query, List<param>? @params = null);
        public PageSummary PaginationSummary(int totalCount, int perPage, int Page);
        public DataSet GetDataSet(string query, List<param>? @params = null);
    }
}
