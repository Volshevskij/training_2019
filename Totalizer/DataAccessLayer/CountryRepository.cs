using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CountryRepository : SqlServerAccesor , ICountryRepository
    {
        public IEnumerable<Country> GetItemsList()
        {
            List<Models.Country> countries = new List<Models.Country>();

            const string SQL_EXPRESSION = "FullCountrySelect";

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
                        Models.Country country = new Models.Country();
                        country.Id = reader.GetInt32(0);
                        country.Name = reader.GetString(1);
                        countries.Add(country);
                    }
                }
                reader.Close();
            }
            return countries;
        }

        public Country GetItemById(int id)
        {
            Models.Country country = new Models.Country();

            const string SQL_EXPRESSION = "IDCountrySelect";

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
                        country.Id = reader.GetInt32(0);
                        country.Name = reader.GetString(1);
                    }
                }
                reader.Close();
            }
            return country;
        }

        public void CreateItem(Country country)
        {
            const string SQL_EXPRESSION = "AddCountry";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = country.Name
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

        public void UpdateItem(Country country)
        {
            const string SQL_EXPRESSION = "UpdateCountry";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = country.Id
                };
                command.Parameters.Add(idParam);

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = country.Name
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

        public void DeleteItem(int id)
        {
            const string SQL_EXPRESSION = "DeleteCountry";

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
