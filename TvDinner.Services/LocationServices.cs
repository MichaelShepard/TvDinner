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
        }
    }

