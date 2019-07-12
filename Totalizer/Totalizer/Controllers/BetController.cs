using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class BetController : ApiController
    {
        IBetService service;

        public BetController(IBetService _service)
        {
            service = _service;
        }

        [Route("bet")]
        [HttpPost]
        public void CreateBet(Bet bet)
        {
            service.CreateItem(bet);
        }

        [Route("bet")]
        [HttpPatch]
        public void UpdateBet(Bet bet)
        {
            service.UpdateItem(bet);
        }

        [Route("bet/{id}")]
        [HttpDelete]
        public void DeleteBet(int id)
        {
            service.DeleteItem(id);
        }

        [Route("bet")]
        [HttpGet]
        public IEnumerable<Bet> GetBetsList()
        {
            return service.GetItemsList();
        }

        [Route("bet/{id}")]
        [HttpGet]
        public Bet GetBetByID(int id)
        {
            return service.GetItemById(id);
        }

        [Route("bet")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }
    }
}