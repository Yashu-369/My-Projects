using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.ViewModels
{
    public class WelcomeViewModel
    {
        public List<CategoryViewModel> Categories { get; protected set; }
        public String Name { get; protected set; }
        public WelcomeViewModel(List<CategoryViewModel> categories, String name)
        {
            Categories = categories;
            Name = name;
        }
    }
}