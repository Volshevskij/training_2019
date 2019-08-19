using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace DataAccessLayer.Helpers
{
    public class SqlHelper : ISqlHelper
    {
        private string connectionString { get; set; }

        public SqlHelper()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            if(!CheckConnection())
            {
               GenerateDataBase();
            }
        }

        public bool CheckConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void GenerateDataBase()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string scriptTotalizer = File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\dbscript\TotalizerScript.sql");
            SqlCommand firstCommand = new SqlCommand(scriptTotalizer, conn);
            firstCommand.ExecuteNonQuery();

            string scriptIdentity = File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\dbscript\IdentityScript.sql");
            SqlCommand secondCommand = new SqlCommand(scriptIdentity, conn);
            secondCommand.ExecuteNonQuery();
        }

        public SqlParameter CreateParameter(string name, object value, DbType dbType)
        {
            return new SqlParameter
            {
                ParameterName = name,
                Value = value,
                DbType = dbType,
                Size = 0,
                Direction = ParameterDirection.Input
            };
        }

        public string GetConnectionString()
        {
            return this.connectionString;
        }

        public void Create(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
        }

        public void Update(string commandText, CommandType commandType, SqlParameter[] sqlParameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public void Delete(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
