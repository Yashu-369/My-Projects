using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.Entities
{
    public class SeasonCrop
    {
        public int SeasonCropId { get; set; }

        public int CropId { get; set; }
        public Crop Crop { get; set; }

        public int SeasonId { get; set; }
        public Season Category { get; set; }
    }
}