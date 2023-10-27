using EysHospitalMIS.Models.DTO;
using Microsoft.Extensions.Configuration;
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
    public class DbContext : IDbContext
    {
        string connectionString;

        public DbContext(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // For Insert, Update & StoreProcedure Without Data
        public void ExecuteQuery(string query, List<param> @params)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;

                    foreach(param param in @params)
                    {
                        if(String.IsNullOrEmpty(Convert.ToString(param.SqlValue)))
                        {
                            param.SqlValue = DBNull.Value;
                        }

                        cmd.Parameters.Add(param.ParamName, param.SqlDbType).Value = param.SqlValue;
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public DataTable GetDataTable(string query, List<param>? @params = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (@params != null)
                    {
                        foreach (param param in @params)
                        {
                            if (param.SqlDbType == SqlDbType.Structured)
                            {
                                command.Parameters.Add(param.ParamName, param.SqlDbType).Value = param.SqlValue;
                                continue;
                            }

                            if (String.IsNullOrEmpty(Convert.ToString(param.SqlValue)))
                            {
                                param.SqlValue = DBNull.Value;
                            }
                            command.Parameters.Add(param.ParamName, param.SqlDbType).Value = param.SqlValue;
                        }
                    }

                    DataTable data = new DataTable();
                    data.Load(command.ExecuteReader());

                    return data;
                }
            }
        }

        public PageSummary PaginationSummary(int totalCount, int perPage, int page)
        {
            decimal lastPage = (decimal)totalCount / perPage;

            PageSummary pageSummary = new()
            {
                Page = page,
                PerPage = perPage,
                FirstPage = 1,
                LastPage = (int)Math.Ceiling(lastPage),
                TotalNumberOfRecord = totalCount
            };

            return pageSummary;
        }
    }
}
