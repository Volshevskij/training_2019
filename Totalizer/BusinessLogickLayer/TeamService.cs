using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class TeamService : ITeamService
    {
        IRepository<Team> sqlDataAccess;

        public TeamService(IRepository<Team> _sqlDataAccess)
        {
            sqlDataAccess = _sqlDataAccess;
        }

        public void CreateItem(Team team)
        {
            sqlDataAccess.CreateItem(team);
        }

        public void UpdateItem(Team team)
        {
            sqlDataAccess.UpdateItem(team);
        }

        public void DeleteItem(int id)
        {
            sqlDataAccess.DeleteItem(id);
        }

        public IEnumerable<Team> GetItemsList()
        {
            return sqlDataAccess.GetItemsList();
        }

        public Team GetItemById(int id)
        {
            return sqlDataAccess.GetItemById(id);
        }
    }
}
