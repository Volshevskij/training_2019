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

        [Authorize(Roles = "User")]
        [Route("bet")]
        [HttpPost]
        public IHttpActionResult CreateBet(Bet bet)
        {
            service.CreateItem(bet);
            return Created("bet", bet);
        }

        [Authorize(Roles = "User")]
        [Route("bet")]
        [HttpPatch]
        public IHttpActionResult UpdateBet(Bet bet)
        {
            service.UpdateItem(bet);
            return Ok();
        }

        [Authorize(Roles = "User")]
        [Route("bet/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBet(int id)
        {
            service.DeleteItem(id);
            return Ok();
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

        [Route("match_bet/{id}")]
        [HttpGet]
        public IEnumerable<Bet> GetMatchingBet(int id)
        {
            return service.GetMatchingBet(id);
        }
    }
}