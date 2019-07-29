using DataAccessLayer.Exceptions;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class EventRepository : IEventRepository
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
            if (@event == null)
            {
                throw new NullEventException("Null event object received");
            }

            const string SQL_EXPRESSION = "AddEvent";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Date", @event.Date, DbType.DateTime),
                helper.CreateParameter("@Team1", @event.Team1.Id, DbType.Int32),
                helper.CreateParameter("@Team2", @event.Team2.Id, DbType.Int32),
                helper.CreateParameter("@SportType", @event.SportType.Id, DbType.Int32),
                helper.CreateParameter("@Status", @event.Status, DbType.String)
            };

            helper.Create(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());        
        }

        public void UpdateItem(Event @event)
        {
            if (@event == null)
            {
                throw new NullEventException("Null event object received");
            }

            const string SQL_EXPRESSION = "UpdateEvents";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", @event.Id, DbType.Int32),
                helper.CreateParameter("@Date", @event.Date, DbType.DateTime),
                helper.CreateParameter("@Team1", @event.Team1.Id, DbType.Int32),
                helper.CreateParameter("@Team2", @event.Team2.Id, DbType.Int32),
                helper.CreateParameter("@SportType", @event.SportType.Id, DbType.Int32),
                helper.CreateParameter("@Status", @event.Status, DbType.String)
            };

            helper.Update(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void DeleteItem(int id)
        {
            const string SQL_EXPRESSION = "DeleteEvent";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", id, DbType.Int32)
            };

            helper.Delete(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
