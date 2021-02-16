using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvDinner.Data;
using TvDinner.Models;

namespace TvDinner.Services
{
    public class LocationService
    { 
            private readonly Guid _userId;

            public LocationService(Guid userId)
            {
                _userId = userId;
            }

            public bool CreateLocation(LocationCreate model)
            {
                var entity =
                    new Location()
                    {
                        Continent = model.Continent,
                        Country = model.Country,
                        State_Territory = model.State_Territory,
                        City = model.City
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Locations.Add(entity);
                    return ctx.SaveChanges() == 1;
                }


            }

            public IEnumerable<LocationList> GetLocation()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Locations

                            .Select(
                                e =>
                                    new LocationList
                                    {
                                        LocationID = e.LocationID,
                                        Continent = e.Continent,
                                        Country = e.Country,
                                        State_Territory = e.State_Territory,
                                        City = e.City
                                    }
                            );

                    return query.ToArray();
                }
            }

        public LocationDetail GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == id);
                return
                    new LocationDetail
                    {
                        LocationID = entity.LocationID,
                        Continent = entity.Continent,
                        Country = entity.Country,
                        State_Territory = entity.State_Territory,
                        City = entity.City
                    };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == model.LocationID);

                entity.Continent = model.Continent;
                entity.Country = model.Country;
                entity.State_Territory = model.State_Territory;
                entity.City = model.City;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == locationID);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

