using AspNetCoreRestaurantApp.Services.Interfaces;
using AspNetCoreRestaurantApp.Services.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreRestaurantApp.Services.Implementation
{
    public class RestaurantManager : IRestaurantManager
    {
        public IRestaurant GetRestaurant(int id)
        {
            return RestaurantRepository.GetRestaurants()
                .FirstOrDefault(r => r.Id == id);
        }

        public List<IRestaurant> GetRestaurants()
        {
            return RestaurantRepository.GetRestaurants()
                .OrderBy(r=>r.Id)
                .ToList();
        }
    }
}
