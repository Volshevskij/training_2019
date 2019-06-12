using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SqlServerPersonModelAccess : SqlServerAccesor,IRepository<Person>
    {
        public IEnumerable<Person> GetItemsList()
        {
            List<Models.Person> persons = new List<Models.Person>();

            const string SQL_EXPRESSION = "FullPersonSelect";

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
                        Models.Person person = new Models.Person();
                        person.Id = reader.GetInt32(0);
                        person.FirstName = reader.GetString(1);
                        person.MiddleName = reader.GetString(2);
                        person.LastName = reader.GetString(3);
                        person.Email = reader.GetString(4);
                        person.Phone = reader.GetString(5);
                        persons.Add(person);
                    }
                }
                reader.Close();
            }
            return persons;
        }

        public Person GetItemById(int id)
        {
            Models.Person person = new Models.Person();

            const string SQL_EXPRESSION = "IDPersonSelect";

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
                        person.Id = reader.GetInt32(0);
                        person.FirstName = reader.GetString(1);
                        person.MiddleName = reader.GetString(2);
                        person.LastName = reader.GetString(3);
                        person.Email = reader.GetString(4);
                        person.Phone = reader.GetString(5);
                    }
                }
                reader.Close();
            }
            return person;
        }

        public void CreateItem(Person person)
        {
            const string SQL_EXPRESSION = "AddPerson";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = person.FirstName
                };
                command.Parameters.Add(nameParam);

                SqlParameter middleNameParam = new SqlParameter
                {
                    ParameterName = "@MiddleName",
                    Value = person.MiddleName
                };
                command.Parameters.Add(middleNameParam);

                SqlParameter lastNameParam = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = person.LastName
                };
                command.Parameters.Add(lastNameParam);

                SqlParameter EmailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = person.Email
                };
                command.Parameters.Add(EmailParam);

                SqlParameter phoneParam = new SqlParameter
                {
                    ParameterName = "@Phone",
                    Value = person.Phone
                };
                command.Parameters.Add(phoneParam);

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

        public void UpdateItem(Person person)
        {
            const string SQL_EXPRESSION = "UpdatePerson";

            using (SqlConnection connection = new SqlConnection(convertedConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = person.Id
                };
                command.Parameters.Add(idParam);

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = person.FirstName
                };
                command.Parameters.Add(nameParam);

                SqlParameter middleNameParam = new SqlParameter
                {
                    ParameterName = "@MiddleName",
                    Value = person.MiddleName
                };
                command.Parameters.Add(middleNameParam);

                SqlParameter lastNameParam = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = person.LastName
                };
                command.Parameters.Add(lastNameParam);

                SqlParameter EmailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = person.Email
                };
                command.Parameters.Add(EmailParam);

                SqlParameter phoneParam = new SqlParameter
                {
                    ParameterName = "@Phone",
                    Value = person.Phone
                };
                command.Parameters.Add(phoneParam);

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
            const string SQL_EXPRESSION = "DeletePerson";

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
