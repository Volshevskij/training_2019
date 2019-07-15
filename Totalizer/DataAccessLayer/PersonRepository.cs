using DataAccessLayer.Exceptions;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class PersonRepository : IPersonRepository
    {
        private ISqlHelper helper;

        public PersonRepository(ISqlHelper _helper)
        {
            helper = _helper;
        }

        public IEnumerable<Person> GetItemsList()
        {
            List<Models.Person> persons = new List<Models.Person>();

            const string SQL_EXPRESSION = "FullPersonSelect";

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
                        Models.Person person = new Models.Person();
                        person.Id = reader.GetInt32(0);
                        person.FirstName = reader.GetString(1);
                        person.MiddleName = reader.GetString(2);
                        person.LastName = reader.GetString(3);
                        person.Email = reader.GetString(4);
                        person.Phone = reader.GetString(5);
                        person.Role = new Role();
                        person.Role.Id = reader.GetInt32(6);
                        person.Password = reader.GetString(7);
                        person.Login = reader.GetString(8);
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
                        person.Id = reader.GetInt32(0);
                        person.FirstName = reader.GetString(1);
                        person.MiddleName = reader.GetString(2);
                        person.LastName = reader.GetString(3);
                        person.Email = reader.GetString(4);
                        person.Phone = reader.GetString(5);
                        person.Role = new Role();
                        person.Role.Id = reader.GetInt32(6);
                        person.Password = reader.GetString(7);
                        person.Login = reader.GetString(8);
                    }
                }
                reader.Close();
            }
            return person;
        }

        public void CreateItem(Person person)
        {
            if (person == null)
            {
                throw new NullPersonException("Null person object received");
            }

            const string SQL_EXPRESSION = "AddPerson";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", person.FirstName, DbType.String),
                helper.CreateParameter("@MiddleName", person.MiddleName, DbType.String),
                helper.CreateParameter("@LastName", person.LastName, DbType.String),
                helper.CreateParameter("@Email", person.Email, DbType.String),
                helper.CreateParameter("@Phone", person.Phone, DbType.String),
                helper.CreateParameter("@Role", person.Role.Id, DbType.Int32),
                helper.CreateParameter("@Password", person.Password, DbType.String),
                helper.CreateParameter("@Login", person.Login, DbType.String)
            };

            helper.Create(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void UpdateItem(Person person)
        {
            if (person == null)
            {
                throw new NullPersonException("Null person object received");
            }

            const string SQL_EXPRESSION = "UpdatePersons";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", person.Id, DbType.Int32),
                helper.CreateParameter("@Name", person.FirstName, DbType.String),
                helper.CreateParameter("@MiddleName", person.MiddleName, DbType.String),
                helper.CreateParameter("@LastName", person.LastName, DbType.String),
                helper.CreateParameter("@Email", person.Email, DbType.String),
                helper.CreateParameter("@Phone", person.Phone, DbType.String),
                helper.CreateParameter("@Role", person.Role.Id, DbType.Int32),
                helper.CreateParameter("@Password", person.Password, DbType.String),
                helper.CreateParameter("@Login", person.Login, DbType.String)
            };

            helper.Update(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void DeleteItem(int id)
        {
            const string SQL_EXPRESSION = "DeletePerson";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", id, DbType.Int32)
            };

            helper.Delete(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
