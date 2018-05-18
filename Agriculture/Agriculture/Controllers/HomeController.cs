using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Agriculture.Models;
using Agriculture.Models.ViewModels;
using Agriculture.Models.Entities;
using Agriculture.Infrastructure;
using HashAndSalt;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agriculture.Controllers
{
    public class HomeController : Controller
    {
            private IEventDomainModel repository;

            public HomeController(IEventDomainModel repo)
            {
                repository = repo;
            }

            public IActionResult Index()
            {
                ViewBag.Customer = GetCustomer();
                return Categories();
            }

            public ViewResult Products()
            {

                CropsViewModel cropsViewModel = new CropsViewModel(repository.Crops);

                return View("Crops", cropsViewModel);
            }

        public ViewResult Crop(int cropID)
        {
            Crop crop = repository.Crops.Single(p => p.CropId == cropID);
            CustomerViewModel customersViewModel = GetCustomer();
            if (customersViewModel.FirstName != null)
            {
                ViewBag.Customer = GetCustomer();
            }
            CropViewModel cropViewModel = new CropViewModel(crop, true);

            var comments = repository.CropsFeedbacks.Where(d => d.CropId.Equals(cropID)).ToList();
            ViewBag.Comments = comments;

            var ratings = repository.CropsFeedbacks.Where(d => d.CropId.Equals(cropID)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(cropViewModel);
        }

            public ViewResult Categories()
            {
                CategoriesViewModel categoriesViewModel = new CategoriesViewModel(repository.Seasons);
                CustomerViewModel customersViewModel = GetCustomer();
                if (customersViewModel.FirstName != null)
                {
                    ViewBag.Customer = GetCustomer();
                }
                return View("Categories", categoriesViewModel);
            }

            public ViewResult Category(int SeasonID)
            {
                ViewBag.Customer = GetCustomer();
                Season category = repository.Seasons.Single(s => s.SeasonId == SeasonID);

                CategoryViewModel categoryViewModel = new CategoryViewModel(category, true);
                return View(categoryViewModel);
            }

            public ViewResult Customers()
            {
                CustomersViewModel customersViewModel = new CustomersViewModel();
                foreach (Customer customer in repository.Customers)
                {
                    customersViewModel.CustomerViewModels.Add(new CustomerViewModel(customer));
                }
                return View("Customers", customersViewModel);
            }

            [HttpGet]
            public ViewResult Register()
            {
                return View();
            }

            [HttpPost]
            public ViewResult Register(CustomerViewModel customerViewModel)
            {
                if (ModelState.IsValid) //valid
                {
                    customerViewModel.GeneratePasswordHash();
                    if (!repository.AddCustomer(customerViewModel.Customer)) //returns false if already there
                        return View();
                //make sure the customer was added correctly before saving the session
                Customer customer = repository.Customers.Single(c => (c.Email == customerViewModel.Email
                                                            && c.PasswordHash == customerViewModel.PasswordHash));
                SaveCustomer(new CustomerViewModel(customer));
                ViewBag.Customer = GetCustomer();

                return Customers();
                }
                else //invalid
                {
                    return View();
                }
            }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid) //valid
            {
                PasswordManager pwdManager = new PasswordManager();
                Customer customer = repository.Customers.Single(c => c.Email == loginViewModel.Email);

                bool result = pwdManager.IsPasswordMatch(loginViewModel.Password, customer.Salt, customer.PasswordHash);
                if (result)
                {
                    SaveCustomer(new CustomerViewModel(customer));
                    ViewBag.Customer = GetCustomer();
                    return View("LoginSuccessful", loginViewModel);
                }
                return View();
            }
            else //invalid
            {
                return View();
            }
        }
        private CustomerViewModel GetCustomer()
        {
            CustomerViewModel customer = HttpContext.Session.GetJson<CustomerViewModel>("Customer") ?? new CustomerViewModel();
            return customer;
        }
        private void SaveCustomer(CustomerViewModel sustomer)
        {
            HttpContext.Session.SetJson("Customer", sustomer);
            var myComplexObject = HttpContext.Session.GetJson<CustomerViewModel>("Customer");
        }

        public ActionResult CropFeedback(int? id)
        {
            Crop crop = repository.Crops.Single(p => p.CropId == id);
            ViewBag.ArticleId = id.Value; //CropID

            var comments = repository.CropsFeedbacks.Where(d => d.CropId.Equals(id.Value)).ToList();
            ViewBag.Comments = comments;

            var ratings = repository.CropsFeedbacks.Where(d => d.CropId.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(crop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection form)
        {
            var comment = form["Comment"].ToString();
            var cropId = int.Parse(form["ArticleId"]);
            var rating = int.Parse(form["Rating"]);

            CropsFeedback artComment = new CropsFeedback()
            {
                CropId = cropId,
                Feedback = comment,
                Rating = rating,
                ThisDateTime = DateTime.Now
            };

            repository.AddFeedback(artComment);

            return RedirectToAction("Crop", "Home", new { cropID = artComment.CropId });
        }

        [HttpGet]
        public ViewResult AddCrop()
        {
            CategoriesViewModel categoriesViewModel = new CategoriesViewModel(repository.Seasons);
            List<SelectListItem> items = new List<SelectListItem>();
            CropViewModel cropViewModel = new CropViewModel();
            for (int c = 0; c < categoriesViewModel.Categories.Count; c++)
            {
                items.Add(new SelectListItem { Text = categoriesViewModel.Categories[c].Name
                    , Value = Convert.ToString(categoriesViewModel.Categories[c].Id)
                });
            }
            //cropViewModel.Categories = categoriesViewModel.Categories;
            ViewBag.Seasons = items;
            
            return View();
        }

        [HttpPost]
        public IActionResult AddCrop(IFormCollection form)
        {
            if (ModelState.IsValid) //valid
            {
                var SeasonID = Convert.ToInt32(form["Seasons"].ToString());

                Crop newCrop = new Crop();
                newCrop.Name = form["Name"].ToString();
                newCrop.PesticidesUsed = form["PesticidesUsed"].ToString();
                newCrop.CropImage = form["CropImage"].ToString();
                newCrop.Price = Convert.ToSingle(form["Price"]);

                repository.AddCrop(newCrop, SeasonID);

                return Categories();
            }
            else //invalid
            {
                return View();
            }
        }
    }
}
