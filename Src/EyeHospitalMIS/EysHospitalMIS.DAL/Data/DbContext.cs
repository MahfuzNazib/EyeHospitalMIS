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
        readonly string connectionString;

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

        public int ExecuteQueryWithId(string query, List<param> @params)
        {
            int insertedId;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;

                    foreach (param param in @params)
                    {
                        if (String.IsNullOrEmpty(Convert.ToString(param.SqlValue)))
                        {
                            param.SqlValue = DBNull.Value;
                        }

                        cmd.Parameters.Add(param.ParamName, param.SqlDbType).Value = param.SqlValue;
                    }

                    con.Open();
                    insertedId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return insertedId;
        }


        public void MultiTableExecuteQuery(string firstQuery, List<param> @firstParams, string secondQuery, List<param> @secondParams, string foreignKeyName)
        {
            using (SqlConnection connection= new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    int insertedRecordId;

                    using(SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Store Data Into First Table
                            using(SqlCommand firstCommand = new SqlCommand(firstQuery, connection, transaction))
                            {
                                foreach(param param in firstParams)
                                {
                                    if (String.IsNullOrEmpty(Convert.ToString(param.SqlValue)))
                                    {
                                        param.SqlValue = DBNull.Value;
                                    }

                                    firstCommand.Parameters.Add(param.ParamName, param.SqlDbType).Value = param.SqlValue;
                                }

                                firstCommand.ExecuteNonQuery();
                                insertedRecordId = Convert.ToInt32(firstCommand.ExecuteScalar());
                            }

                            // Store Data Into Second Table
                            using (SqlCommand secondCommand = new SqlCommand(secondQuery, connection, transaction))
                            {
                                foreach (param param in secondParams)
                                {
                                    if (String.IsNullOrEmpty(Convert.ToString(param.SqlValue)))
                                    {
                                        param.SqlValue = DBNull.Value;
                                    }

                                    secondCommand.Parameters.Add(param.ParamName, param.SqlDbType).Value = param.SqlValue;
                                }
                                //secondCommand.Parameters.Add(foreignKeyName, SqlDbType.Int).Value = insertedRecordId;
                                secondCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch(Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception();
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception();
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


        public DataSet GetDataSet(string query, List<param>? @params = null)
        {
            DataSet dataSet = new DataSet();
            
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(var command = new SqlCommand(query, connection))
                {
                    if(@params!= null)
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

                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet);
                        }

                        return dataSet;
                    }
                }
            }

            return null;
        }
    }
}
