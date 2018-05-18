using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.Entities
{
    public class Season
    {
        public String Name { get; set; }
        public int SeasonId { get; set; }
        public virtual IEnumerable<SeasonCrop> SeasonCrops { get; set; }
    }
}