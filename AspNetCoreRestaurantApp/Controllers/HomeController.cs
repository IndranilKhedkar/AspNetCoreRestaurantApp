using System;
using System.Collections.Generic;
using AspNetCoreRestaurantApp.Models;
using AspNetCoreRestaurantApp.Resources;
using AspNetCoreRestaurantApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRestaurantApp.Services.Implementation;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreRestaurantApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantManager _restaurantManager;
        private IGreeter _greeter;

        public HomeController(IRestaurantManager restaurantManager, IGreeter greeter)
        {
            _restaurantManager = restaurantManager;
            _greeter = greeter;
        }

        [AllowAnonymous]
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


        [HttpGet]
        [ActionName("Create")]
        public IActionResult RestaurantCreate()
        {
            return View(nameof(RestaurantCreate));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult RestaurantCreate(RestaurantEditModel restaurant)
        {
            if (!ModelState.IsValid)
                return View(nameof(RestaurantCreate));

            var res = new Restaurant()
            {
                Address = restaurant.Address,
                Cuisine = restaurant.CuisineType,
                Name = restaurant.Name
            };

            IRestaurant result = _restaurantManager.AddRestaurant(res);
            return RedirectToAction("Details", new { id = result.Id });
        }

        [HttpGet]
        [ActionName("Edit")]
        public IActionResult RestaurantEdit(int id)
        {
            var model = _restaurantManager.GetRestaurant(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(RestaurantEdit), GetRestaurantEditModel(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult RestaurantEdit(int id, RestaurantEditModel restaurant)
        {
            if (!ModelState.IsValid || id <= 0)
                return View(nameof(RestaurantEdit), restaurant);

            var res = new Restaurant()
            {
                Address = restaurant.Address,
                Cuisine = restaurant.CuisineType,
                Name = restaurant.Name
            };

            if (_restaurantManager.EditRestaurant(id, res))
                return RedirectToAction("Details", new { id = id });

            return View(nameof(RestaurantEdit), restaurant);
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

        private RestaurantEditModel GetRestaurantEditModel(IRestaurant restaurant)
        {
            return new RestaurantEditModel()
            {
                Name = restaurant.Name,
                CuisineType = restaurant.Cuisine,
                Address = restaurant.Address
            };
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
