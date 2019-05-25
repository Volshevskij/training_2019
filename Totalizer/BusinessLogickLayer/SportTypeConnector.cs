using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogickLayer
{
    class SportTypeConnector
    {
        SqlServerSportTypeModelAccess sqlDataAccess = new SqlServerSportTypeModelAccess();

        public void AddSportType(SportType sportType)
        {
            sqlDataAccess.CreateItem(sportType);
        }

        public void UpdateSportType(SportType sportType)
        {
            sqlDataAccess.UpdateItem(sportType);
        }

        public void DeleteSportType(SportType sportType)
        {
            sqlDataAccess.DeleteItem(sportType);
        }

        public IEnumerable<SportType> GetSportTypes()
        {
            return sqlDataAccess.GetItemsList();
        }

        public SportType GetSportTypeByID(int id)
        {
            return sqlDataAccess.GetItemByID(id);
        }
    }
}
