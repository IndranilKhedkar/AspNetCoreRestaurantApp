using AspNetCoreRestaurantApp.Services.Interfaces;
using AspNetCoreRestaurantApp.Services.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreRestaurantApp.Services.Implementation
{
    public class RestaurantManager : IRestaurantManager
    {
        public IRestaurant AddRestaurant(Restaurant restaurant)
        {
            var restaurantId = this.GetRestaurants().Max(r => r.Id) + 1;
            restaurant.Id = restaurantId;
            RestaurantRepository.AddRestaurant(restaurant);
            return GetRestaurant(restaurantId);
        }

        public bool EditRestaurant(int id, Restaurant res)
        {
            IRestaurant restaurant = this.GetRestaurant(id);
            if (restaurant != null)
            {
                restaurant.Name = res.Name;
                restaurant.Cuisine = res.Cuisine;
                restaurant.Address = res.Address;
                return true;
            }
            return false;
        }

        public IRestaurant GetRestaurant(int id)
        {
            return RestaurantRepository.GetRestaurants()
                .FirstOrDefault(r => r.Id == id);
        }

        public List<IRestaurant> GetRestaurants()
        {
            return RestaurantRepository.GetRestaurants()
                .OrderBy(r => r.Id)
                .ToList();
        }
    }
}
