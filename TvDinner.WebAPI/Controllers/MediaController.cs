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

    [Authorize]
    public class MediaController : ApiController
    {
        
        private MediaService CreateMediaService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var mediaService = new MediaService (userId);
            return mediaService;

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            MediaService mediaService = CreateMediaService();
            var media = mediaService.GetMedia();
            return Ok(media);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            MediaService mediaService = CreateMediaService();
            var media = mediaService.GetMediaById(id);
            return Ok(media);
        }

        [HttpGet]
        [Route("api/Media/GetLocationByMediaTitle")]
        public IHttpActionResult GetLocationByMediaTitle(string mediaTitle)
        {
            MediaService mediaService = CreateMediaService();
            var mediaLocation = mediaService.GetLocationByMediaTitle(mediaTitle);
            return Ok(mediaLocation);
        }

        [HttpGet]
        [Route("api/Media/GetMediaByTitle")]
        public IHttpActionResult GetMediaByTitle(string mediaTitle)
        {
            MediaService mediaService = CreateMediaService();
            var mediaFromTitle = mediaService.GetMediaByTitle(mediaTitle);
            return Ok(mediaFromTitle);
        }

        [HttpGet]
        [Route("api/Media/GetReceipeByMediaTitle")]
        public IHttpActionResult GetRecipesByMediaTitle(string mediaTitle)
        {
            MediaService mediaService = CreateMediaService();
            var mediaFromTitle = mediaService.GetRecipesByMediaTitle(mediaTitle);
            return Ok(mediaFromTitle);
        }


        [HttpPost]
        public IHttpActionResult Post(MediaCreate media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMediaService();

            if (!service.CreateMedia(media))
                return InternalServerError();

            return Ok();

        }
        
        [HttpPut]
        [Route("api/Media/UpdateLocationOfMedia")]
        public IHttpActionResult PutMediaLocationUpdate(MediaLocationUpdate media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMediaService();

            if (!service.UpdateMediaLocation(media))
                return InternalServerError();

            return Ok();

        }

        [HttpPut]
        public IHttpActionResult Put(MediaEdit media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMediaService();

            if (!service.UpdateMedia(media))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMediaService();

            if (!service.DeleteMedia(id))
                return InternalServerError();

            return Ok();
        }



    }
}
