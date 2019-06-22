using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class BetService:IBetService
    {
        IRepository<Bet> sqlDataAccess;

        public BetService(IRepository<Bet> _sqlDataAccess)
        {
            sqlDataAccess = _sqlDataAccess;
        }

        public void CreateItem(Bet bet)
        {
            sqlDataAccess.CreateItem(bet);
        }

        public void UpdateItem(Bet bet)
        {
            sqlDataAccess.UpdateItem(bet);
        }

        public void DeleteItem(int id)
        {
            sqlDataAccess.DeleteItem(id);
        }

        public IEnumerable<Bet> GetItemsList()
        {
            return sqlDataAccess.GetItemsList();
        }
 
        public Bet GetItemById(int id)
        {
            return sqlDataAccess.GetItemById(id);
        }
    }
}
