using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogickLayer
{
    class CountryConnector
    {
        SqlServerCountryModelAccess sqlDataAccess = new SqlServerCountryModelAccess();

        public void AddBet(Country country)
        {
            sqlDataAccess.CreateItem(country);
        }

        public void UpdateBet(Country country)
        {
            sqlDataAccess.UpdateItem(country);
        }

        public void DeleteBet(Country country)
        {
            sqlDataAccess.DeleteItem(country);
        }

        public IEnumerable<Country> GetBets()
        {
            return sqlDataAccess.GetItemsList();
        }

        public Country GetBetByID(int id)
        {
            return sqlDataAccess.GetItemByID(id);
        }
    }
}
