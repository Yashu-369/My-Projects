using Agriculture.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.ViewModels
{
    public class CategoriesViewModel
    {
        public List<CategoryViewModel> Categories { get; protected set; }

        public CategoriesViewModel(IEnumerable<Season> categories)
        {

            Categories = new List<CategoryViewModel>();
            foreach (Season category in categories)
            {
                this.Categories.Add(new CategoryViewModel(category));
            }

        }
    }
}