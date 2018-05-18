using Agriculture.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.ViewModels
{
    public class CategoryViewModel
    {
        private Season category;
        private IEnumerable<Crop> enumerable;

        public List<CropViewModel> Crops { get; protected set; }
        public String Name { get; protected set; }
        public int Id { get; protected set; }

       

        public CategoryViewModel(int id, String name)
        {
            this.Id = id;
            Crops = new List<CropViewModel>();
            this.Name = name;


        }
        public CategoryViewModel(int id, String name, IEnumerable<Crop> Seasons) : this(id, name)
        {
            foreach (Crop season in Seasons)
            {
                this.Crops.Add(new CropViewModel(season));
            }
        }

        public CategoryViewModel(Season category, Boolean populateProducts = false)
        {
            this.Id = category.SeasonId;
            this.Name = category.Name;
            Crops = new List<CropViewModel>();
            if (populateProducts)
            {
                foreach (SeasonCrop categoryProduct in category.SeasonCrops)
                {
                    Crops.Add(new CropViewModel(categoryProduct.Crop, false));
                }
            }
        }

        public CategoryViewModel(Season category, IEnumerable<SeasonCrop> categoryCrops, IEnumerable<Crop> events)
        {
            this.Id = category.SeasonId;
            this.Name = category.Name;
            Crops = new List<CropViewModel>();
            var result = from e in events
                         join ce in categoryCrops on e.CropId equals ce.CropId
                         where (ce.SeasonId == category.SeasonId) //only necessary if crops contains ALL the crops
                         select new
                         {
                             EventId = e.CropId,
                             Name = e.Name,
                             Budget = e.Price,
                             ArrangementItems = e.PesticidesUsed,
                             PhotoShoot = e.CropImage,
                         };
            foreach (var p in result)
            {
                Crops.Add(new CropViewModel(p.EventId, p.Name, p.Budget, p.ArrangementItems, p.PhotoShoot));
            }
        }

        override public String ToString()
        {
            return Name;
        }
    }
}