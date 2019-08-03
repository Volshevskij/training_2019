using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer.Interfaces
{
    public interface IBetService : IService<Bet>
    {
        IEnumerable<Bet> GetMatchingBet(int id);
    }
}
