using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agriculture.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            if (!context.Crops.Any())
            {
                Crop rice = new Crop { Name = "Rice", PesticidesUsed = "Alugor & Carbondyzium", Price = 39.99F, CropImage = @"http://newsfirst.lk/english/wp-content/uploads/2015/08/Rice.jpg", CategoryCrops = new List<SeasonCrop>() };
                Crop ragi = new Crop { Name = "Ragi", PesticidesUsed = "Clorophoriphos", Price = 29.99F, CropImage = @"https://www.yummytummyaarthi.com/wp-content/uploads/2014/01/IMG_1731.jpg", CategoryCrops = new List<SeasonCrop>() };
                Crop sugarcane = new Crop { Name = "Sugar", PesticidesUsed = "Phorates, Monocrotophos", Price = 9.99F, CropImage = @"http://frucery.com/wp-content/uploads/2017/06/sugar.jpg", CategoryCrops = new List<SeasonCrop>() };
                Crop maize = new Crop { Name = "Maize", PesticidesUsed = "Rocket", Price = 59.99F, CropImage = @"https://image.shutterstock.com/z/stock-photo-corn-seed-or-maize-on-brown-sack-background-in-the-field-of-farmland-497675698.jpg", CategoryCrops = new List<SeasonCrop>() };
                Crop sunflower = new Crop { Name = "sunflower", PesticidesUsed = "Rogar", Price = 99.99F, CropImage = @"http://cf.ltkcdn.net/vegetarian/images/std/201986-675x450-sunflower-seeds.jpg", CategoryCrops = new List<SeasonCrop>() };
                Crop groundnuts = new Crop { Name = "Groundnuts", PesticidesUsed = "Rogar", Price = 19.99F, CropImage = @"http://connectnigeria.com/articles/wp-content/uploads/2013/07/groundnut.jpg", CategoryCrops = new List<SeasonCrop>() };
                Crop wheat = new Crop { Name = "Wheat", PesticidesUsed = "Monocrotophos", Price = 39.99F, CropImage = @"http://www.agweek.com/sites/default/files/styles/full_1000/public/field/image/Wheat%20li%20jingwang%20istockphoto_16.jpg?itok=S-88W-FL.", CategoryCrops = new List<SeasonCrop>() };
                Crop cotton = new Crop { Name = "Cotton", PesticidesUsed = "Rocket", Price = 69.99F, CropImage = @"https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/CottonPlant.JPG/1200px-CottonPlant.JPG", CategoryCrops = new List<SeasonCrop>() };
                Crop jowar = new Crop { Name = "Jowar", PesticidesUsed = "Rocket", Price = 49.99F, CropImage = @"https://it.all.biz/img/it/catalog/101436.jpeg", CategoryCrops = new List<SeasonCrop>() };
                Crop mustard = new Crop { Name = "Mustard", PesticidesUsed = "Anugar", Price = 89.99F, CropImage = @"https://static.thespicehouse.com/images/file/1124/large_square_Brown_Mustard_Seed__Whole__close.jpg", CategoryCrops = new List<SeasonCrop>() };

                Season summerCrops = new Season { Name = "Summer", SeasonCrops = new List<SeasonCrop>() };
                Season rainyCrops = new Season { Name = "Rainy", SeasonCrops = new List<SeasonCrop>() };
                Season winterCrops = new Season { Name = "Winter", SeasonCrops = new List<SeasonCrop>() };


                context.Crops.AddRange(rice, ragi);

                context.Seasons.AddRange(summerCrops, rainyCrops, winterCrops);
                context.SeasonCrop.AddRange(
                    new SeasonCrop { Crop = rice, Category = summerCrops },
                    new SeasonCrop { Crop = rice, Category = rainyCrops },

                    new SeasonCrop { Crop = sugarcane, Category = summerCrops },

                    new SeasonCrop { Crop = ragi, Category = summerCrops },
                    new SeasonCrop { Crop = ragi, Category = rainyCrops },

                    new SeasonCrop { Crop = maize, Category = summerCrops },
                    new SeasonCrop { Crop = maize, Category = rainyCrops },
                    new SeasonCrop { Crop = maize, Category = winterCrops },

                    new SeasonCrop { Crop = sunflower, Category = summerCrops },
                    new SeasonCrop { Crop = sunflower, Category = rainyCrops },
                    new SeasonCrop { Crop = sunflower, Category = winterCrops },

                    new SeasonCrop { Crop = groundnuts, Category = summerCrops },

                    new SeasonCrop { Crop = cotton, Category = rainyCrops },
                    new SeasonCrop { Crop = cotton, Category = winterCrops },

                    new SeasonCrop { Crop = wheat, Category = winterCrops },

                     new SeasonCrop { Crop = jowar, Category = rainyCrops },
                      new SeasonCrop { Crop = jowar, Category = winterCrops },

                      new SeasonCrop { Crop = mustard, Category = winterCrops }

                   );

                context.Customers.AddRange(
                    new Customer { Email = "something@something.com", FirstName = "John", LastName = "Smith", Password = "weak",PrivilegeId =1 },
                    new Customer { Email = "justin.ehrlich@gmail.com", FirstName = "Justin", LastName = "Ehrlich", PasswordHash = "뱖篚鋒ꋬ笝綄ꡙ㎱�껩Զ靁歭蓟ꌻ", Salt = "⃷壍ⰿ䠤⫞坣搻ꚷᬈ裤䬩粜", PrivilegeId = 0});


                context.SaveChanges();
            }
        }
    }
}
