using Agriculture.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.ViewModels
{
    public class CropViewModel
    {
        private Crop events;
        private IEnumerable<Season> enumerable;

        public int Id { get; protected set; }
        public String Name { get; protected set; }
        public float Price { get; protected set; }
        public string PesticidesUsed { get; protected set; }
        public String CropImage { get; protected set; }
        public List<CategoryViewModel> Categories { get; protected set; }

        public CropViewModel(int id, String name, float price, string PesticidesUsed, string photo)
        {
            Categories = new List<CategoryViewModel>();
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.PesticidesUsed = PesticidesUsed;
            this.CropImage = photo;
        }

        public CropViewModel()
        {

        }

        public CropViewModel(Crop newEvent, Boolean populateCategories = false)
        {
            Categories = new List<CategoryViewModel>();
            this.Id = newEvent.CropId;
            this.Name = newEvent.Name;
            this.Price = newEvent.Price;
            this.PesticidesUsed = newEvent.PesticidesUsed;
            this.CropImage = newEvent.CropImage;
            if (populateCategories)
            {
                foreach (SeasonCrop categoryEvents in newEvent.CategoryCrops)
                {
                    Categories.Add(new CategoryViewModel(categoryEvents.Category, false));
                }
            }
        }

        override public String ToString()
        {
            return this.Name;
        }
    }
}
