using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SqlServerEventModelAccess :SqlServerAccesor, IRepository<Event>
    {
        public IEnumerable<Event> GetItemsList()
        {
            List<Models.Event> events = new List<Models.Event>();

            const string SQL_EXPRESSION = "FullEventSelect";

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
                        Models.Event @event = new Models.Event();
                        @event.Id = reader.GetInt32(0);
                        @event.Date = reader.GetDateTime(1);
                        @event.Team1 = new Team();
                        @event.Team1.Id = reader.GetInt32(2);
                        @event.Team1.Name = reader.GetString(3);
                        @event.Team2 = new Team();
                        @event.Team2.Id = reader.GetInt32(4);
                        @event.Team2.Name = reader.GetString(5);
                        @event.SportType = new SportType();
                        @event.SportType.Id = reader.GetInt32(6);
                        @event.SportType.Name = reader.GetString(7);
                        events.Add(@event);
                    }
                }
                reader.Close();
            }
            return events;
        }

        public Event GetItemByID(int id)
        {
            Models.Event @event = new Models.Event();

            const string SQL_EXPRESSION = "IDEventSelect";

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
                        @event.Id = reader.GetInt32(0);
                        @event.Date = reader.GetDateTime(1);
                        @event.Team1 = new Team();
                        @event.Team1.Id = reader.GetInt32(2);
                        @event.Team1.Name = reader.GetString(3);
                        @event.Team2 = new Team();
                        @event.Team2.Id = reader.GetInt32(4);
                        @event.Team2.Name = reader.GetString(5);
                        @event.SportType = new SportType();
                        @event.SportType.Id = reader.GetInt32(6);
                        @event.SportType.Name = reader.GetString(7);
                    }
                }
                reader.Close();
            }
            return @event;
        }

        public void CreateItem(Event @event)
        {
            const string SQL_EXPRESSION = "AddEvent";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = @event.Date
                };
                command.Parameters.Add(dateParam);

                SqlParameter team1Param = new SqlParameter
                {
                    ParameterName = "@Team1",
                    Value = @event.Team1
                };
                command.Parameters.Add(team1Param);

                SqlParameter team2Param = new SqlParameter
                {
                    ParameterName = "@Team2",
                    Value = @event.Team2
                };
                command.Parameters.Add(team2Param);

                SqlParameter sportTypeParam = new SqlParameter
                {
                    ParameterName = "@SportType",
                    Value = @event.SportType
                };
                command.Parameters.Add(sportTypeParam);

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

        public void UpdateItem(Event @event)
        {
            const string SQL_EXPRESSION = "UpdateEvent";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = @event.Id
                };
                command.Parameters.Add(idParam);

                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = @event.Date
                };
                command.Parameters.Add(dateParam);

                SqlParameter team1Param = new SqlParameter
                {
                    ParameterName = "@Team1",
                    Value = @event.Team1
                };
                command.Parameters.Add(team1Param);

                SqlParameter team2Param = new SqlParameter
                {
                    ParameterName = "@Team2",
                    Value = @event.Team2
                };
                command.Parameters.Add(team2Param);

                SqlParameter sportTypeParam = new SqlParameter
                {
                    ParameterName = "@SportType",
                    Value = @event.SportType
                };
                command.Parameters.Add(sportTypeParam);

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

        public void DeleteItem(Event @event)
        {
            const string SQL_EXPRESSION = "DeleteEvent";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = @event.Id
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
