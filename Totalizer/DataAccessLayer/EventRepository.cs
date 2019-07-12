using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class EventRepository :SqlServerAccesor, IEventRepository
    {
        private ISqlHelper helper;

        public EventRepository(ISqlHelper _helper)
        {
            helper = _helper;
        }

        public IEnumerable<Event> GetItemsList()
        {
            List<Models.Event> events = new List<Models.Event>();

            const string SQL_EXPRESSION = "FullEventSelect";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                        @event.Status = reader.GetString(5);
                        @event.Team1 = new Team();
                        @event.Team1.Id = reader.GetInt32(6);
                        @event.Team1.Name = reader.GetString(7);
                        @event.Team1.Country = new Country();
                        @event.Team1.Country.Id = reader.GetInt32(8);
                        @event.Team2 = new Team();
                        @event.Team2.Id = reader.GetInt32(9);
                        @event.Team2.Name = reader.GetString(10);
                        @event.Team2.Country = new Country();
                        @event.Team2.Country.Id = reader.GetInt32(11);
                        @event.SportType = new SportType();
                        @event.SportType.Id = reader.GetInt32(12);
                        @event.SportType.Name = reader.GetString(13);
                        events.Add(@event);
                    }
                }
                reader.Close();
            }
            return events;
        }

        public Event GetItemById(int id)
        {
            Models.Event @event = new Models.Event();

            const string SQL_EXPRESSION = "IDEventSelect";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                        @event.Status = reader.GetString(5);
                        @event.Team1 = new Team();
                        @event.Team1.Id = reader.GetInt32(6);
                        @event.Team1.Name = reader.GetString(7);
                        @event.Team1.Country = new Country();
                        @event.Team1.Country.Id = reader.GetInt32(8);
                        @event.Team2 = new Team();
                        @event.Team2.Id = reader.GetInt32(9);
                        @event.Team2.Name = reader.GetString(10);
                        @event.Team2.Country = new Country();
                        @event.Team2.Country.Id = reader.GetInt32(11);
                        @event.SportType = new SportType();
                        @event.SportType.Id = reader.GetInt32(12);
                        @event.SportType.Name = reader.GetString(13);
                    }
                }
                reader.Close();
            }
            return @event;
        }

        public void CreateItem(Event @event)
        {
            const string SQL_EXPRESSION = "AddEvent";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                    Value = @event.Team1.Id
                };
                command.Parameters.Add(team1Param);

                SqlParameter team2Param = new SqlParameter
                {
                    ParameterName = "@Team2",
                    Value = @event.Team2.Id
                };
                command.Parameters.Add(team2Param);

                SqlParameter sportTypeParam = new SqlParameter
                {
                    ParameterName = "@SportType",
                    Value = @event.SportType.Id
                };
                command.Parameters.Add(sportTypeParam);

                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@Status",
                    Value = @event.Status
                };
                command.Parameters.Add(statusParam);

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
            const string SQL_EXPRESSION = "UpdateEvents";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                    Value = @event.Team1.Id
                };
                command.Parameters.Add(team1Param);

                SqlParameter team2Param = new SqlParameter
                {
                    ParameterName = "@Team2",
                    Value = @event.Team2.Id
                };
                command.Parameters.Add(team2Param);

                SqlParameter sportTypeParam = new SqlParameter
                {
                    ParameterName = "@SportType",
                    Value = @event.SportType.Id
                };
                command.Parameters.Add(sportTypeParam);

                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@Status",
                    Value = @event.Status
                };
                command.Parameters.Add(statusParam);

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
            const string SQL_EXPRESSION = "DeleteEvent";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
