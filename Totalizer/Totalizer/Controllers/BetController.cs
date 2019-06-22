using BusinessLogickLayer.Interfaces;
using Models;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class BetController : ApiController
    {
        IBetService connector;

        public BetController(IBetService _connector)
        {
            connector = _connector;
        }

        public void CreateBet(Bet bet)
        {
            connector.CreateItem(bet);
        }

        public void UpdateBet(Bet bet)
        {
            connector.UpdateItem(bet);
        }

        public void DeleteBet(int id)
        {
            connector.DeleteItem(id);
        }

        [Route("bet")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        public string GetBetsList()
        {
            string countriesString = JsonConvert.SerializeObject(connector.GetItemsList());
            return countriesString;
        }

        public Bet GetBetByID(int id)
        {
            return connector.GetItemById(id);
        }
    }
}