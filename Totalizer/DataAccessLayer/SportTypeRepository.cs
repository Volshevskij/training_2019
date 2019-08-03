using DataAccessLayer.Exceptions;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SportTypeRepository : ISportTypeRepository
    {
        private ISqlHelper helper;

        public SportTypeRepository(ISqlHelper _helper)
        {
            helper = _helper;
        }

        public IEnumerable<SportType> GetItemsList()
        {
            List<Models.SportType> sportTypes = new List<Models.SportType>();

            const string SQL_EXPRESSION = "FullSportTypesSelect";

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

        public SportType GetItemById(int id)
        {
            Models.SportType sportType = new Models.SportType();

            const string SQL_EXPRESSION = "IDSportTypeSelect";

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
            if (sportType == null)
            {
                throw new NullSportTypeException("Null sport type object received");
            }

            const string SQL_EXPRESSION = "AddSportType";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", sportType.Name, DbType.String)
            };

            helper.Create(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void UpdateItem(SportType sportType)
        {
            if (sportType == null)
            {
                throw new NullSportTypeException("Null sport type object received");
            }

            const string SQL_EXPRESSION = "UpdateSportTypes";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", sportType.Id, DbType.Int32),
                helper.CreateParameter("@Name", sportType.Name, DbType.String)
            };

            helper.Update(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void DeleteItem(int id)
        {
            const string SQL_EXPRESSION = "DeleteSportType";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", id, DbType.Int32)
            };

            helper.Delete(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
