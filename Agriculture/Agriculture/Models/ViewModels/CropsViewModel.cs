using Agriculture.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.ViewModels
{
    public class CropsViewModel
    {
        public List<CropViewModel> Crops { get; protected set; }

        public CropsViewModel(IEnumerable<Crop> events)
        {
            Crops = new List<CropViewModel>();
            foreach (Crop newEvent in events)
            {
                this.Crops.Add(new CropViewModel(newEvent));
            }
        }
    }
}