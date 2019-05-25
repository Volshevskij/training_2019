using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogickLayer
{
    class TeamConnector
    {
        SqlServerTeamModelAccess sqlDataAccess = new SqlServerTeamModelAccess();

        public void AddTeam(Team team)
        {
            sqlDataAccess.CreateItem(team);
        }

        public void UpdateTeam(Team team)
        {
            sqlDataAccess.UpdateItem(team);
        }

        public void DeleteTeam(Team team)
        {
            sqlDataAccess.DeleteItem(team);
        }

        public IEnumerable<Team> GetTeams()
        {
            return sqlDataAccess.GetItemsList();
        }

        public Team GetTeamByID(int id)
        {
            return sqlDataAccess.GetItemByID(id);
        }
    }
}
