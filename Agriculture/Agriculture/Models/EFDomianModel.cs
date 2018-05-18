using Agriculture.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models
{
    public class EFDomainModel : IEventDomainModel
    {
        private ApplicationDbContext context;
        public EFDomainModel(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SeasonCrop> SeasonsCrops
        {
            get { return context.SeasonCrop; }
        }

        public IEnumerable<Crop> Crops
        {
            //using eager loading: https://docs.microsoft.com/en-us/ef/core/querying/related-data
            get { return context.Crops.Include(c => c.CategoryCrops).ThenInclude(cp => cp.Category); }
        }

        //lazy loading is not available in EF Core, so this is how you do explicit loading
        //public Category GetCategory(int categoryId)
        //{
        //    var category = context.Categories
        //         .Single(c => c.CategoryId == categoryId);

        //    context.Entry(category)
        //        .Collection(c => c.CategoryProducts)
        //        .Load();
        //    return category;
        //}
        public IEnumerable<Season> Seasons
        {
            get { return context.Seasons.Include(c => c.SeasonCrops).ThenInclude(cp => cp.Crop); }
        }

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public void UpdateCustomer(Customer customer)
        {

            Customer currentCustomer = Customers.Single(c => c.CustomerId == customer.CustomerId);
            currentCustomer.UpdateValues(customer);
            context.SaveChanges();
        }

        public bool AddCustomer(Customer customer)
        {
            //make sure the user doesn't already exist
            foreach (Customer tempCustomer in Customers)
            {
                if (tempCustomer.Email.CompareTo(customer.Email) == 0)
                    return false;
            }
            context.Customers.Add(customer);

            context.SaveChanges();
            return true;
        }

        public IEnumerable<CropsFeedback> CropsFeedbacks
        {
            get { return context.CropsFeedbacks; }
        }

        public bool AddFeedback(CropsFeedback feedback)
        {
           
            context.CropsFeedbacks.Add(feedback);

            context.SaveChanges();
            return true;
        }

        public bool AddCrop(Crop crop, int seasonID)
        {
            context.Crops.Add(crop);

            SeasonCrop seasonCrop = new SeasonCrop();
            seasonCrop.CropId = crop.CropId;
            seasonCrop.SeasonId = seasonID;
            context.SeasonCrop.Add(seasonCrop);

            context.SaveChanges();
            return true;
        }
    }
}