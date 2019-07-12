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
        protected string ConnectionString { get; set; }

        public SqlServerAccesor()
        {
            SetConnetction();
        }

        private void SetConnetction()
        {
           ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[CONNECTION_TYPE].ToString();     
        }

    }
}
