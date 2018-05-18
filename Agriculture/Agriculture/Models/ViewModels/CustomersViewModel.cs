using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.ViewModels
{
    public class CustomersViewModel
    {
        public List<CustomerViewModel> CustomerViewModels { get; set; }
        public CustomersViewModel()
        {
            CustomerViewModels = new List<CustomerViewModel>();
        }
    }
}