using Agriculture.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models
{
    public interface IEventDomainModel
    {
        IEnumerable<Crop> Crops { get; }
        IEnumerable<Season> Seasons { get; }
        IEnumerable<SeasonCrop> SeasonsCrops { get; }
        IEnumerable<Customer> Customers { get; }
        IEnumerable<CropsFeedback> CropsFeedbacks { get;}

        bool AddFeedback(CropsFeedback feedback);

        bool AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);

        bool AddCrop(Crop crop, int seasonID);
    }
}