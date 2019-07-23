using DataAccessLayer.Exceptions;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private ISqlHelper helper;

        public UserRepository(ISqlHelper _helper)
        {
            helper = _helper;
        }

        public IEnumerable<User> GetItemsList()
        {
            List<Models.User> users = new List<Models.User>();

            const string SQL_EXPRESSION = "FullUserSelect";

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
                        Models.User user = new Models.User();
                        user.Id = reader.GetInt32(0);
                        user.Login = reader.GetString(1);
                        user.Person = new Person();
                        user.Person.Id = reader.GetInt32(2);
                        users.Add(user);
                    }
                }
                reader.Close();
            }
            return users;
        }

        public User GetItemById(int id)
        {
            Models.User user = new Models.User();

            const string SQL_EXPRESSION = "IDUserSelect";

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
                        user.Id = reader.GetInt32(0);
                        user.Login = reader.GetString(1);
                        user.Person = new Person();
                        user.Person.Id = reader.GetInt32(2);
                    }
                }
                reader.Close();
            }
            return user;
        }

        public void CreateItem(User user)
        {
            if (user == null)
            {
                throw new NullUserException("Null user object received");
            }

            const string SQL_EXPRESSION = "AddUser";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Login", user.Login, DbType.String),
                helper.CreateParameter("@PersonId", user.Person.Id, DbType.Int32)
            };

            helper.Create(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void UpdateItem(User user)
        {
            if (user == null)
            {
                throw new NullUserException("Null user object received");
            }

            const string SQL_EXPRESSION = "UpdateUsers";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", user.Id, DbType.Int32),
                helper.CreateParameter("@Login", user.Login, DbType.String),
                helper.CreateParameter("@PersonId", user.Person.Id, DbType.Int32)
            };

            helper.Update(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void DeleteItem(int id)
        {
            const string SQL_EXPRESSION = "DeleteUser";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", id, DbType.Int32)
            };

            helper.Delete(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public User GetMatchingUser(string login)
        {
            Models.User user = new Models.User();

            const string SQL_EXPRESSION = "GetMatchingUser";

            using (SqlConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_EXPRESSION, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = login
                };
                command.Parameters.Add(loginParam);

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.Login = reader.GetString(1);
                        user.Person = new Person();
                        user.Person.Id = reader.GetInt32(2);
                    }
                }
                reader.Close();
            }

            if(user == null || user.Login == "" || user.Person == null || user.Login == null)
            {
                return null;
            }

            return user;
        }
    }
}
