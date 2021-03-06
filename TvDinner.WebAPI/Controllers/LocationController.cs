using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TvDinner.Models;
using TvDinner.Services;

namespace TvDinner.WebAPI.Controllers
{
    public class LocationController : ApiController
    {
        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var locationService = new LocationService(userId);
            return locationService;
        }
        public IHttpActionResult Post(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult GetByID(int id)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationById(id);
            return Ok(location);
        }
        public IHttpActionResult GetLocation()
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocation();
            return Ok(location);
        }
        [HttpGet]
        [Route("api/Location/GetLocationByCountry")]
        public IHttpActionResult GetLocationByCountry(string country)
        {
            LocationService locationService = CreateLocationService();
            var locationFromCountry = locationService.GetLocationByCountry(country);
            return Ok(locationFromCountry);
        }

        [HttpGet]
        [Route("api/Location/GetLocationByContinent")]
        public IHttpActionResult GetLocationByContinent(string continent)
        {
            LocationService locationService = CreateLocationService();
            var locationFromContinent = locationService.GetLocationByContinent(continent);
            return Ok(locationFromContinent);
        }

        [HttpGet]
        [Route("api/Location/GetLocationByCity")]
        public IHttpActionResult GetLocationByCity(string city)
        {
            LocationService locationService = CreateLocationService();
            var locationFromCity = locationService.GetLocationByCity(city);
            return Ok(locationFromCity);
        }
        public IHttpActionResult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.UpdateLocation(location))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateLocationService();

            if (!service.DeleteLocation(id))
                return InternalServerError();

            return Ok();
        }
    }
}
