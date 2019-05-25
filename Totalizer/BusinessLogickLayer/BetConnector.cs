using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogickLayer
{
    public class BetConnector
    {
        SqlServerBetModelAccess sqlDataAccess = new SqlServerBetModelAccess();

        public void AddBet(Bet bet)
        {
            sqlDataAccess.CreateItem(bet);
        }

        public void UpdateBet(Bet bet)
        {
            sqlDataAccess.UpdateItem(bet);
        }

        public void DeleteBet(Bet bet)
        {
            sqlDataAccess.DeleteItem(bet);
        }

        public IEnumerable<Bet> GetBets()
        {
            return sqlDataAccess.GetItemsList();
        }
 
        public Bet GetBetByID(int id)
        {
            return sqlDataAccess.GetItemByID(id);
        }
    }
}
