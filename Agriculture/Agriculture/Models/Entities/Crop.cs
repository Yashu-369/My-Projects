using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.Entities
{
    public class Crop
    {
        public int CropId { get; set; }
        public String Name { get; set; }
        public float Price { get; set; }
        public string PesticidesUsed { get; set; }
        public String CropImage { get; set; }
        public virtual IEnumerable<SeasonCrop> CategoryCrops { get; set; }
    }
}