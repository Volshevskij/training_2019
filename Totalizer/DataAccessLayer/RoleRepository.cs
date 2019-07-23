using DataAccessLayer.Exceptions;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class RoleRepository : IRoleRepository
    {
        private ISqlHelper helper;

        public RoleRepository(ISqlHelper _helper)
        {
            helper = _helper;
        }

        public IEnumerable<Role> GetItemsList()
        {
            List<Models.Role> roles = new List<Models.Role>();

            const string SQL_EXPRESSION = "FullRolesSelect";

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
                        Models.Role role = new Models.Role();
                        role.Id = reader.GetInt32(0);
                        role.Name = reader.GetString(1);
                        roles.Add(role);
                    }
                }
                reader.Close();
            }
            return roles;
        }

        public Role GetItemById(int id)
        {
            Models.Role role = new Models.Role();

            const string SQL_EXPRESSION = "IDRoleSelect";

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
                        role.Id = reader.GetInt32(0);
                        role.Name = reader.GetString(1);
                    }
                }
                reader.Close();
            }
            return role;
        }

        public void CreateItem(Role role)
        {
            if (role == null)
            {
                throw new NullRoleException("Null role object received");
            }

            const string SQL_EXPRESSION = "AddRole";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", role.Name, DbType.String)
            };

            helper.Create(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void UpdateItem(Role role)
        {
            if (role == null)
            {
                throw new NullRoleException("Null role object received");
            }

            const string SQL_EXPRESSION = "UpdateRoles";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", role.Id, DbType.Int32),
                helper.CreateParameter("@Name", role.Name, DbType.String)
            };

            helper.Update(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }

        public void DeleteItem(int id)
        {
            const string SQL_EXPRESSION = "DeleteRole";

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@ID", id, DbType.Int32),
            };

            helper.Delete(SQL_EXPRESSION, CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
