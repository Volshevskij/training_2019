using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SqlServerSportTypeModelAccess : SqlServerAccesor,IRepository<SportType>
    {
        public IEnumerable<SportType> GetItemsList()
        {
            List<Models.SportType> sportTypes = new List<Models.SportType>();

            const string SQL_EXPRESSION = "FullSportTypesSelect";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Models.SportType sportType = new Models.SportType();
                        sportType.Id = reader.GetInt32(0);
                        sportType.Name = reader.GetString(1);
                        sportTypes.Add(sportType);
                    }
                }
                reader.Close();
            }
            return sportTypes;
        }

        public SportType GetItemByID(int id)
        {
            Models.SportType sportType = new Models.SportType();

            const string SQL_EXPRESSION = "IDSportTypeSelect";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = id
                };
                command.Parameters.Add(idParam);

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sportType.Id = reader.GetInt32(0);
                        sportType.Name = reader.GetString(1);
                    }
                }
                reader.Close();
            }
            return sportType;
        }

        public void CreateItem(SportType sportType)
        {
            const string SQL_EXPRESSION = "AddSportType";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = sportType.Name
                };
                command.Parameters.Add(nameParam);

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

        public void UpdateItem(SportType sportType)
        {
            const string SQL_EXPRESSION = "UpdateSportType";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = sportType.Id
                };
                command.Parameters.Add(idParam);

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = sportType.Name
                };
                command.Parameters.Add(nameParam);

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

        public void DeleteItem(SportType sportType)
        {
            const string SQL_EXPRESSION = "DeleteSportType";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = sportType.Id
                };
                command.Parameters.Add(idParam);

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
