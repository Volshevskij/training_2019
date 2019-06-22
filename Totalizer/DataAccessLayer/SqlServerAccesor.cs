using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class SqlServerAccesor
    {
        protected const string CONNECTION_TYPE = "DefaultConnection";
        protected string convertedConnectionString;

        public SqlServerAccesor()
        {
            SetConnetction();
        }

        private void SetConnetction()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[CONNECTION_TYPE];
            convertedConnectionString = Convert.ToString(connectionString);        
        }

    }
}
