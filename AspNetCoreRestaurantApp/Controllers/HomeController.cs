using System;
using System.Collections.Generic;
using AspNetCoreRestaurantApp.Models;
using AspNetCoreRestaurantApp.Resources;
using AspNetCoreRestaurantApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreRestaurantApp.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantManager _restaurantManager;
        private IGreeter _greeter;
        public HomeController(IRestaurantManager restaurantManager, IGreeter greeter)
        {
            _restaurantManager = restaurantManager;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel()
            {
                MessageOfTheDay = _greeter.GetMessageOfTheDay(),
                Restaurants = GetRestaurants()
            };
            return View(model);
        }

        [ActionName("Details")]
        public IActionResult RestaurantDetails(int id)
        {
            var model = _restaurantManager.GetRestaurant(id);
            if (model == null)
            {
                return View("Error", new ErrorViewModel()
                {
                    Message = Resource.DefaultErrorMessageText
                });
            }

            return View(nameof(RestaurantDetails), GetRestaurantViewModel(model));
        }

        [ActionName("Create")]
        [HttpGet]
        public IActionResult RestaurantCreate()
        {
            return View(nameof(RestaurantCreate));
        }

        [ActionName("Create")]
        [HttpPost]
        public IActionResult RestaurantCreate(RestaurantEditModel restaurant)
        {
            if (restaurant != null)
            {

            }
            return View(nameof(RestaurantCreate));
        }

        #region Private Methods
        private List<RestaurantViewModel> GetRestaurants()
        {
            List<RestaurantViewModel> restaurantList = new List<RestaurantViewModel>();
            var restaurants = _restaurantManager.GetRestaurants();
            if (restaurants == null || restaurants.Count < 1)
                return restaurantList;

            foreach (var restaurant in restaurants)
            {
                restaurantList.Add(GetRestaurantViewModel(restaurant));
            }

            return restaurantList;
        }

        private RestaurantViewModel GetRestaurantViewModel(IRestaurant restaurant)
        {
            return new RestaurantViewModel()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                CuisineType = restaurant.Cuisine,
                Address = restaurant.Address
            };
        }
        #endregion
    }
}
