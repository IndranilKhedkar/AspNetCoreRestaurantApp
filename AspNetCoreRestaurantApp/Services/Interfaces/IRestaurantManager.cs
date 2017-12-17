using System.Collections.Generic;
using AspNetCoreRestaurantApp.Services.Implementation;

namespace AspNetCoreRestaurantApp.Services.Interfaces
{
    public interface IRestaurantManager
    {
        List<IRestaurant> GetRestaurants();
        IRestaurant GetRestaurant(int id);
        IRestaurant AddRestaurant(Restaurant restaurant);
        bool EditRestaurant(int id, Restaurant res);
    }
}