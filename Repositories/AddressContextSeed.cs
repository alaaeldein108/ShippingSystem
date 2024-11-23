using Data.Context;
using Data.Entities.Addresses;
using Data.Entities.Operation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class AddressContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.Provinces != null && !context.Provinces.Any())
                {
                    var provincesData = File.ReadAllText("../Repositories/SeedData/Provinces.json");
                    var provinces = JsonSerializer.Deserialize<List<Province>>(provincesData);
                    if (provinces is not null)
                    {
                        await context.Provinces.AddRangeAsync(provinces);
                    }
                }
                //await context.SaveChangesAsync();

                if (context.Cities != null && !context.Cities.Any())
                {
                    var citiesData = File.ReadAllText("../Repositories/SeedData/Cities.json");
                    var cities = JsonSerializer.Deserialize<List<City>>(citiesData);
                    if (cities is not null)
                    {
                        await context.Cities.AddRangeAsync(cities);
                    }
                }
               // await context.SaveChangesAsync();

                if (context.Areas != null && !context.Areas.Any())
                {
                    var areasData = File.ReadAllText("../Repositories/SeedData/Areas.json");
                    var areas = JsonSerializer.Deserialize<List<Area>>(areasData);
                    if (areas is not null)
                    {
                        await context.Areas.AddRangeAsync(areas);
                    }
                }
               
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(ex.Message);
            }
        }

    }
}
