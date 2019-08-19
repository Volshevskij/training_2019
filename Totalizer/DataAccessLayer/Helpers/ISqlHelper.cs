using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Helpers
{
    public interface ISqlHelper
    {
        SqlParameter CreateParameter(string name, object value, DbType dbType);
        string GetConnectionString();
        bool CheckConnection();
        void GenerateDataBase();

        void Delete(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null);
        void Create(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null);
        void Update(string commandText, CommandType commandType, SqlParameter[] sqlParameters);
    }
}
