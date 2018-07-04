using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            //used for views that combine to controllers
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay(); ;

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant() { Name = model.Name, cuisineType = model.cuisineType };
                _restaurantData.Add(newRestaurant);

                //Inorder to prevent the user from submitting a payment twice we redirect
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            return View();
        }
    }
}
