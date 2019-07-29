using DataAccessLayer.Exceptions;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CountryRepository : ICountryRepository
    {
        private ISqlHelper helper;

        public CountryRepository(ISqlHelper _helper)
        {
            helper = _helper;
        }

        public IEnumerable<Country> GetItemsList()
        {
            List<Models.Country> countries = new List<Models.Country>();

            const string SQL_EXPRESSION = "FullCountrySelect";

            using (SqlConnection connection = new SqlConnection(helper.GetConnectionString()))
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

            using (SqlConnection connection = new SqlConnection(helper.GetConnectionString()))
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
            if(country == null)
            {
                throw new NullCountryException("Null country object received");
            }

            const string SQL_EXPRESSION = "AddCountry";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", country.Name, DbType.String)
            };

            helper.Create(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void UpdateItem(Country country)
        {
            if (country == null)
            {
                throw new NullCountryException("Null country object received");
            }

            const string SQL_EXPRESSION = "UpdateCountries";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", country.Id, DbType.Int32),
                helper.CreateParameter("@Name", country.Name, DbType.String)
            };

            helper.Update(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());

        }

        public void DeleteItem(int id)
        {
            const string SQL_EXPRESSION = "DeleteCountry";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", id, DbType.Int32)
            };

            helper.Delete(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
