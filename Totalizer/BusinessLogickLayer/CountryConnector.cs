using BusinessLogickLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class CountryConnector:ILogickRepository<Country>
    {
        IRepository<Country> sqlDataAccess = new SqlServerCountryModelAccess();

        //public CountryConnector(IRepository<Country> _sqlDataAccess)
        //{
        //    sqlDataAccess = _sqlDataAccess;
        //}

        public void CreateItem(Country country)
        {
            sqlDataAccess.CreateItem(country);
        }

        public void UpdateItem(Country country)
        {
            sqlDataAccess.UpdateItem(country);
        }

        public void DeleteItem(int id)
        {
            sqlDataAccess.DeleteItem(id);
        }

        public IEnumerable<Country> GetItemsList()
        {
            return sqlDataAccess.GetItemsList();
        }

        public Country GetItemById(int id)
        {
            return sqlDataAccess.GetItemById(id);
        }
    }
}
