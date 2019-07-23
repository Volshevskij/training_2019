using DataAccessLayer.Interfaces;
using DataAccessLayer.Helpers;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer.Exceptions;

namespace DataAccessLayer
{
    public class TeamRepository : ITeamRepository
    {
        private ISqlHelper helper;

        public TeamRepository(ISqlHelper _helper)
        {
            helper = _helper;
        }

        public IEnumerable<Team> GetItemsList()
        {
            List<Models.Team> teams = new List<Models.Team>();

            const string SQL_EXPRESSION = "FullTeamsSelect";

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
                        Models.Team team = new Models.Team();
                        team.Id = reader.GetInt32(0);
                        team.Name = reader.GetString(1);
                        team.Country = new Country();
                        team.Country.Id = reader.GetInt32(3);
                        team.Country.Name = reader.GetString(4);
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
                        team.Id = reader.GetInt32(0);
                        team.Name = reader.GetString(1);
                        team.Country = new Country();
                        team.Country.Id = reader.GetInt32(3);
                        team.Country.Name = reader.GetString(4);
                    }
                }
                reader.Close();
            }
            return team;
        }

        public void CreateItem(Team team)
        {
            if (team == null)
            {
                throw new NullTeamException("Null team object received");
            }

            const string SQL_EXPRESSION = "AddTeam";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", team.Name, DbType.String),
                helper.CreateParameter("@Country", team.Country.Id, DbType.Int32)
            };

            helper.Create(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void UpdateItem(Team team)
        {
            if (team == null)
            {
                throw new NullTeamException("Null team object received");
            }

            const string SQL_EXPRESSION = "UpdateTeam";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", team.Id, DbType.Int32),
                helper.CreateParameter("@Name", team.Name, DbType.String),
                helper.CreateParameter("@Country", team.Country.Id, DbType.Int32)
            };

            helper.Update(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void DeleteItem(int id)
        {
            const string SQL_EXPRESSION = "DeleteTeam";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", id, DbType.Int32)
            };

            helper.Delete(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
