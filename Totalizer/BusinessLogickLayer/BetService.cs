﻿using BusinessLogickLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Models;
using System.Collections.Generic;

namespace BusinessLogickLayer
{
    public class BetService : IBetService
    {
        IBetRepository repository;

        public BetService(IBetRepository _repository)
        {
            repository = _repository;
        }

        public void CreateItem(Bet bet)
        {
            repository.CreateItem(bet);
        }

        public void UpdateItem(Bet bet)
        {
            repository.UpdateItem(bet);
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public IEnumerable<Bet> GetItemsList()
        {
            return repository.GetItemsList();
        }
 
        public Bet GetItemById(int id)
        {
            return repository.GetItemById(id);
        }

        public IEnumerable<Bet> GetMatchingBet(int id)
        {
           return repository.GetMatchingBet(id);
        }
    }
}
