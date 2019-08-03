using Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IBetRepository : IRepository<Bet>
    {
        IEnumerable<Bet> GetMatchingBet(int id);
    }
}
