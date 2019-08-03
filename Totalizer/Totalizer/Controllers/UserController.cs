using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        IUserService userService;
        IPersonService personService;
        IBetService betService;

        public UserController(IUserService _userService, IPersonService _personService, IBetService _betService)
        {
            userService = _userService;
            personService = _personService;
            betService = _betService;
        }

        [Route("user")]
        [HttpGet]
        public IEnumerable<User> GetUsersList()
        {
            return userService.GetItemsList();
        }

        [Route("user")]
        [HttpGet]
        public User GetUserById(int id)
        {
            return userService.GetItemById(id);
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
           userService.DeleteItem(id);
           return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("user")]
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            userService.CreateItem(user);
            return Created("user", user);
        }

        [Authorize(Roles = "Admin")]
        [Route("user")]
        [HttpPatch]
        public IHttpActionResult UpdateUser([FromBody]User user)
        {
            userService.UpdateItem(user);
            return Ok();
        }

        [Route("user/{login}")]
        [HttpGet]
        public Person GetMatchingUser(string login)
        {
            if (userService.GetMatchingUser(login) == null)
            {
                User tmp = new User();
                tmp.Id = 0;
                tmp.Login = login;
                tmp.Person = new Person();
                tmp.Person.Id = personService.AddUndefinedPerson();
                CreateUser(tmp);
                return personService.GetItemById(tmp.Person.Id);
            }          
            return personService.GetItemById(userService.GetMatchingUser(login).Person.Id);
        }

        [Route("matching_bet/{login}")]
        [HttpGet]
        public IEnumerable<Bet> GetMathingBets(string login)
        {
           return betService.GetMatchingBet(GetMatchingUser(login).Id);
        }

        [Route("user")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }
    }
}
