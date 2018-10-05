using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Band.API.Models.DataManager
{
    public class DBSeeder
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {

            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BandContext>();

                using (context)
                {
                    context.Database.Migrate();

                    if (!context.Bands.Any())
                    {
                        var bands = new List<Band>()
                        {
                            new Band(){
                                Name = "Alice In Chains",
                                Genre="Heavy Metal"
                            }
                        };


                        context.Bands.AddRange(bands);
                        context.SaveChanges();
                    }
                }
            }

        }
    }
}
