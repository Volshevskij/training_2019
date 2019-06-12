using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SqlServerTeamModelAccess : SqlServerAccesor, IRepository<Team>
    {
        public IEnumerable<Team> GetItemsList()
        {
            List<Models.Team> teams = new List<Models.Team>();

            const string SQL_EXPRESSION = "FullTeamsSelect";

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
                        Models.Team team = new Models.Team();
                        team.Id = reader.GetInt32(0);
                        team.Name = reader.GetString(1);
                        team.Country = new Country();
                        team.Country.Id = reader.GetInt32(2);
                        team.Country.Name = reader.GetString(3);
                        teams.Add(team);
                    }
                }
                reader.Close();
            }
            return teams;
        }

        public Team GetItemById(int id)
        {
            Models.Team team = new Models.Team();

            const string SQL_EXPRESSION = "IDTeamsSelect";

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
                        team.Id = reader.GetInt32(0);
                        team.Name = reader.GetString(1);
                        team.Country = new Country();
                        team.Country.Id = reader.GetInt32(2);
                        team.Country.Name = reader.GetString(3);
                    }
                }
                reader.Close();
            }
            return team;
        }

        public void CreateItem(Team team)
        {
            const string SQL_EXPRESSION = "AddTeam";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = team.Name
                };
                command.Parameters.Add(nameParam);

                SqlParameter countryParam = new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = team.Country.Id
                };
                command.Parameters.Add(countryParam);

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

        public void UpdateItem(Team team)
        {
            const string SQL_EXPRESSION = "UpdateTeam";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = team.Id
                };
                command.Parameters.Add(idParam);

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = team.Name
                };
                command.Parameters.Add(nameParam);

                SqlParameter countryParam = new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = team.Country.Id
                };
                command.Parameters.Add(countryParam);

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
            const string SQL_EXPRESSION = "DeleteTeam";

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
