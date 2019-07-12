﻿using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public  class BetRepository : SqlServerAccesor, IBetRepository
    {
        private ISqlHelper helper;

        public BetRepository(ISqlHelper _helper)
        {
            helper = _helper;
        }

        public IEnumerable<Bet> GetItemsList()
        {
            List<Models.Bet> bets = new List<Models.Bet>();

            const string SQL_EXPRESSION = "FullBetSelect";

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
                        Models.Bet bet = new Models.Bet();
                        bet.Id = reader.GetInt32(0);
                        bet.Coefficient = reader.GetInt32(3);
                        bet.Date = reader.GetDateTime(4);
                        bet.Amount = reader.GetDecimal(5);

                        bet.Person = new Person();
                        bet.Person.Id = reader.GetInt32(7);
                        bet.Person.FirstName = reader.GetString(8);
                        bet.Person.MiddleName = reader.GetString(9);
                        bet.Person.LastName = reader.GetString(10);
                        bet.Person.Email = reader.GetString(11);
                        bet.Person.Phone = reader.GetString(12);
                        bet.Person.Role = new Role();
                        bet.Person.Role.Id = reader.GetInt32(13);
                        bet.Person.Password = reader.GetString(14);
                        bet.Person.Login = reader.GetString(15);

                        bet.Event = new Event();
                        bet.Event.Id = reader.GetInt32(16);
                        bet.Event.Date = reader.GetDateTime(17);
                        bet.Event.Status = reader.GetString(21);

                        bet.Event.Team1 = new Team();
                        bet.Event.Team1.Id = reader.GetInt32(22);
                        bet.Event.Team1.Name = reader.GetString(23);
                        bet.Event.Team1.Country = new Country();
                        bet.Event.Team1.Country.Id = reader.GetInt32(24);

                        bet.Event.Team2 = new Team();
                        bet.Event.Team2.Id = reader.GetInt32(25);
                        bet.Event.Team2.Name = reader.GetString(26);
                        bet.Event.Team2.Country = new Country();
                        bet.Event.Team2.Country.Id = reader.GetInt32(27);

                        bet.Event.SportType = new SportType();
                        bet.Event.SportType.Id = reader.GetInt32(28);
                        bet.Event.SportType.Name = reader.GetString(29);

                        bet.Team = new Team();
                        bet.Team.Id = reader.GetInt32(30);
                        bet.Team.Name = reader.GetString(31);
                        bet.Team.Country = new Country();
                        bet.Team.Country.Id = reader.GetInt32(32);

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
                        bet.Id = reader.GetInt32(0);
                        bet.Coefficient = reader.GetInt32(3);
                        bet.Date = reader.GetDateTime(4);
                        bet.Amount = reader.GetDecimal(5);

                        bet.Person = new Person();
                        bet.Person.Id = reader.GetInt32(7);
                        bet.Person.FirstName = reader.GetString(8);
                        bet.Person.MiddleName = reader.GetString(9);
                        bet.Person.LastName = reader.GetString(10);
                        bet.Person.Email = reader.GetString(11);
                        bet.Person.Phone = reader.GetString(12);
                        bet.Person.Role = new Role();
                        bet.Person.Role.Id = reader.GetInt32(13);
                        bet.Person.Password = reader.GetString(14);
                        bet.Person.Login = reader.GetString(15);

                        bet.Event = new Event();
                        bet.Event.Id = reader.GetInt32(16);
                        bet.Event.Date = reader.GetDateTime(17);
                        bet.Event.Status = reader.GetString(21);

                        bet.Event.Team1 = new Team();
                        bet.Event.Team1.Id = reader.GetInt32(22);
                        bet.Event.Team1.Name = reader.GetString(23);
                        bet.Event.Team1.Country = new Country();
                        bet.Event.Team1.Country.Id = reader.GetInt32(24);

                        bet.Event.Team2 = new Team();
                        bet.Event.Team2.Id = reader.GetInt32(25);
                        bet.Event.Team2.Name = reader.GetString(26);
                        bet.Event.Team2.Country = new Country();
                        bet.Event.Team2.Country.Id = reader.GetInt32(27);

                        bet.Event.SportType = new SportType();
                        bet.Event.SportType.Id = reader.GetInt32(28);
                        bet.Event.SportType.Name = reader.GetString(29);

                        bet.Team = new Team();
                        bet.Team.Id = reader.GetInt32(30);
                        bet.Team.Name = reader.GetString(31);
                        bet.Team.Country = new Country();
                        bet.Team.Country.Id = reader.GetInt32(32);
                    }
                }
                reader.Close();
            }
            return bet;
        }

        public void CreateItem(Bet bet)
        {
            const string SQL_EXPRESSION = "AddBet";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Person", bet.Person.Id, DbType.Int32)
            };

            helper.Create(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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

                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = bet.Date
                };
                command.Parameters.Add(dateParam);

                SqlParameter amountParam = new SqlParameter
                {
                    ParameterName = "@Amount",
                    Value = bet.Amount
                };
                command.Parameters.Add(amountParam);

                SqlParameter teamParam = new SqlParameter
                {
                    ParameterName = "@Team",
                    Value = bet.Team.Id
                };
                command.Parameters.Add(teamParam);

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
            const string SQL_EXPRESSION = "UpdateBets";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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

                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = bet.Date
                };
                command.Parameters.Add(dateParam);

                SqlParameter amountParam = new SqlParameter
                {
                    ParameterName = "@Amount",
                    Value = bet.Amount
                };
                command.Parameters.Add(amountParam);

                SqlParameter teamParam = new SqlParameter
                {
                    ParameterName = "@Team",
                    Value = bet.Team.Id
                };
                command.Parameters.Add(teamParam);

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