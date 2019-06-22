using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public  class BetRepository : SqlServerAccesor, IBetRepository
    {
        public IEnumerable<Bet> GetItemsList()
        {
            List<Models.Bet> bets = new List<Models.Bet>();

            const string SQL_EXPRESSION = "FullBetSelect";

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
                        Models.Bet bet = new Models.Bet();
                        bet.Id = reader.GetInt32(0);
                        bet.Coefficient = reader.GetInt32(3);
                        bet.Result = reader.GetString(4);
                        bet.Date = reader.GetDateTime(5);
                        bet.Person = new Person();
                        bet.Person.Id = reader.GetInt32(6);
                        bet.Person.FirstName = reader.GetString(7);
                        bet.Person.MiddleName = reader.GetString(8);
                        bet.Person.LastName = reader.GetString(9);
                        bet.Event = new Event();
                        bet.Event.Id = reader.GetInt32(10);
                        bet.Event.Date = reader.GetDateTime(11);
                        bet.Event.Team1 = new Team();
                        bet.Event.Team1.Id = reader.GetInt32(12);
                        bet.Event.Team2 = new Team();
                        bet.Event.Team2.Id = reader.GetInt32(13);
                        bets.Add(bet);
                    }
                }
                reader.Close();
            }
            return bets;
        }

        public Bet GetItemById(int id)
        {
            Models.Bet bet = new Models.Bet();

            const string SQL_EXPRESSION = "IDBetSelect";

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
                        bet.Id = reader.GetInt32(0);
                        bet.Coefficient = reader.GetInt32(3);
                        bet.Result = reader.GetString(4);
                        bet.Date = reader.GetDateTime(5);
                        bet.Person = new Person();
                        bet.Person.Id = reader.GetInt32(6);
                        bet.Person.FirstName = reader.GetString(7);
                        bet.Person.MiddleName = reader.GetString(8);
                        bet.Person.LastName = reader.GetString(9);
                        bet.Event = new Event();
                        bet.Event.Id = reader.GetInt32(10);
                        bet.Event.Date = reader.GetDateTime(11);
                        bet.Event.Team1 = new Team();
                        bet.Event.Team1.Id = reader.GetInt32(12);
                        bet.Event.Team2 = new Team();
                        bet.Event.Team2.Id = reader.GetInt32(13);
                    }
                }
                reader.Close();
            }
            return bet;
        }

        public void CreateItem(Bet bet)
        {
            const string SQL_EXPRESSION = "AddBet";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter personParam = new SqlParameter
                {
                    ParameterName = "@Person",
                    Value = bet.Person.Id
                };
                command.Parameters.Add(personParam);

                SqlParameter eventParam = new SqlParameter
                {
                    ParameterName = "@Event",
                    Value = bet.Event.Id
                };
                command.Parameters.Add(eventParam);

                SqlParameter coefficientParam = new SqlParameter
                {
                    ParameterName = "@Coefficient",
                    Value = bet.Coefficient
                };
                command.Parameters.Add(coefficientParam);

                SqlParameter resultParam = new SqlParameter
                {
                    ParameterName = "@Result",
                    Value = bet.Result
                };
                command.Parameters.Add(resultParam);

                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = bet.Date
                };
                command.Parameters.Add(dateParam);

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

        public void UpdateItem(Bet bet)
        {
            const string SQL_EXPRESSION = "UpdateBet";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = bet.Id
                };
                command.Parameters.Add(idParam);

                SqlParameter personParam = new SqlParameter
                {
                    ParameterName = "@Person",
                    Value = bet.Person.Id
                };
                command.Parameters.Add(personParam);

                SqlParameter eventParam = new SqlParameter
                {
                    ParameterName = "@Event",
                    Value = bet.Event.Id
                };
                command.Parameters.Add(eventParam);

                SqlParameter coefficientParam = new SqlParameter
                {
                    ParameterName = "@Coefficient",
                    Value = bet.Coefficient
                };
                command.Parameters.Add(coefficientParam);

                SqlParameter resultParam = new SqlParameter
                {
                    ParameterName = "@Result",
                    Value = bet.Result
                };
                command.Parameters.Add(resultParam);

                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = bet.Date
                };
                command.Parameters.Add(dateParam);

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
            const string SQL_EXPRESSION = "DeleteBet";

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
