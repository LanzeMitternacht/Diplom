using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;

namespace FlowersShop
{
    public static class DatabaseManager
    {
        private static string _connectionString;
        
        static DatabaseManager()
        {
            InitializeConnectionString();
        }
        
        private static void InitializeConnectionString()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
                
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = "Server=.;Database=FlowerShop;Integrated Security=true;";
                }
            }
            catch
            {
                _connectionString = "Server=.;Database=FlowerShop;Integrated Security=true;";
            }
        }
        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        
        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        
        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    
                    return command.ExecuteNonQuery();
                }
            }
        }
        
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    
                    return command.ExecuteScalar();
                }
            }
        }
        
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
} 