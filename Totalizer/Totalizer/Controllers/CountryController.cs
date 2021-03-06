﻿using BusinessLogickLayer.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Totalizer.Controllers
{
    [RoutePrefix("api")]
    public class CountryController : ApiController
    {
        ICountryService service;

        public CountryController(ICountryService _service)
        {
            service = _service;
        }

        [Route("country")]
        [HttpGet]
        public IEnumerable<Country> GetCountriesList()
        {
            return service.GetItemsList();
        }

        [Route("country/{id}")]
        [HttpGet]
        public Country GetCountryById(int id)
        {
           return service.GetItemById(id);
        }

        [Authorize(Roles = "Editor")]
        [Route("country")]
        [HttpPost]
        public IHttpActionResult CreateCountry(Country country)
        {
            service.CreateItem(country);
            return Created("country", country);
        }

        [Authorize(Roles = "Editor")]
        [Route("country")]
        [HttpPatch]
        public IHttpActionResult UpdateCountry([FromBody]Country country)
        {
            service.UpdateItem(country);
            return Ok();
        }

        [Route("country")]
        [HttpOptions]
        public string Options()
        {
            return null;
        }

        [Authorize(Roles = "Editor")]
        [Route("country/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            service.DeleteItem(id);
            return Ok();
        }
    }
}