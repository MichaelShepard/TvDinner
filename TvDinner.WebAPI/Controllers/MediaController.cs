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


        public IHttpActionResult Get(int id)
        {
            MediaService mediaService = CreateMediaService();
            var media = mediaService.GetMediaById(id);
            return Ok(media);
        }


        public IHttpActionResult Post(MediaCreate media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMediaService();

            if (!service.CreateMedia(media))
                return InternalServerError();

            return Ok();

        }

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
