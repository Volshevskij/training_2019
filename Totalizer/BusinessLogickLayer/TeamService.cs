using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class TeamService : ITeamService
    {
        IRepository<Team> repository;

        public TeamService(IRepository<Team> _repository)
        {
            repository = _repository;
        }

        public void CreateItem(Team team)
        {
            repository.CreateItem(team);
        }

        public void UpdateItem(Team team)
        {
            repository.UpdateItem(team);
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public IEnumerable<Team> GetItemsList()
        {
            return repository.GetItemsList();
        }

        public Team GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
