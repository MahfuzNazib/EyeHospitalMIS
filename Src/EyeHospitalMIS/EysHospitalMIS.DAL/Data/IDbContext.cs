using EysHospitalMIS.Models.DTO;
using System;
using System.Collections.Generic;
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
        public Task<DbDataReader> ExecuteReaderAsync(string query, List<param>? @params = null);
        public DbDataReader ExecuteReader(string query, List<param>? @params = null);
    }
}
