using BusinessLogickLayer.Cacher;
using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class TeamService : ITeamService
    {
        ITeamRepository repository;
        IMemoryCacher memoryCacher;

        public TeamService(ITeamRepository _repository, IMemoryCacher _memoryCacher)
        {
            repository = _repository;
            memoryCacher = _memoryCacher;
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
            return memoryCacher.CheckCache("team", repository.GetItemsList(), DateTimeOffset.UtcNow.AddHours(1)) as IEnumerable<Team>;
        }

        public Team GetItemById(int id)
        {
            return repository.GetItemById(id);
        }
    }
}
