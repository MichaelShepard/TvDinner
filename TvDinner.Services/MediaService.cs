﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvDinner.Data;
using TvDinner.Models;

namespace TvDinner.Services
{
    public class MediaService
    {

        private readonly Guid _userId;

        public MediaService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMedia(MediaCreate model)
        {
            var entity = new Media()
            {
                Title = model.Title,
                Genre = model.Genre,
                MediaType = model.MediaType,
                SeasonEpisode = model.SeasonEpisode,
                SceneOfFood = model.SceneOfFood,
                LocationId = model.LocationId,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Media.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MediaDetails> GetMedia()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Media
                    // .Where(e => e.MediaId == _mediaId) REmove this to get all media
                    .Select(e => new MediaDetails
                    {
                        MediaId = e.MediaId,
                        Title = e.Title,
                        Genre = e.Genre,
                        MediaType = e.MediaType,
                        SeasonEpisode = e.SeasonEpisode,
                        SceneOfFood = e.SceneOfFood,
                        CreatedUtc = e.CreatedUtc
                    });
                return query.ToArray();
            }
        }

        public MediaDetails GetMediaById(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Media.Single(e => e.MediaId == id);
                return
                    new MediaDetails
                    {
                        MediaId = entity.MediaId,
                        Title = entity.Title,
                        Genre = entity.Genre,
                        MediaType = entity.MediaType,
                        SeasonEpisode = entity.SeasonEpisode,
                        SceneOfFood = entity.SceneOfFood,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        public bool UpdateMedia(MediaEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Media.Single(e => e.MediaId == model.MediaId);

                entity.MediaId = model.MediaId;
                entity.Title = model.Title;
                entity.Genre = (Genre)model.Genre;
                entity.MediaType = (MediaType)model.MediaType;
                entity.SeasonEpisode = model.SeasonEpisode;
                entity.SceneOfFood = entity.SceneOfFood;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteMedia(int mediaId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Media.Single(e => e.MediaId == mediaId);

                ctx.Media.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }




    }
}
