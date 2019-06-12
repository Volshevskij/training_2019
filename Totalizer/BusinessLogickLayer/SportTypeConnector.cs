using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class SportTypeConnector : ILogickRepository<SportType>
    {
        IRepository<SportType> sqlDataAccess;

        public SportTypeConnector(IRepository<SportType> _sqlDataAccess)
        {
            sqlDataAccess = _sqlDataAccess;
        }

        public void CreateItem(SportType sportType)
        {
            sqlDataAccess.CreateItem(sportType);
        }

        public void UpdateItem(SportType sportType)
        {
            sqlDataAccess.UpdateItem(sportType);
        }

        public void DeleteItem(int id)
        {
            sqlDataAccess.DeleteItem(id);
        }

        public IEnumerable<SportType> GetItemsList()
        {
            return sqlDataAccess.GetItemsList();
        }

        public SportType GetItemById(int id)
        {
            return sqlDataAccess.GetItemById(id);
        }
    }
}
