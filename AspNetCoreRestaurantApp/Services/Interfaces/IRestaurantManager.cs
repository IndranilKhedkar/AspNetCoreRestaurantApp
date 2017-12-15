using System.Collections.Generic;

namespace AspNetCoreRestaurantApp.Services.Interfaces
{
    public interface IRestaurantManager
    {
        List<IRestaurant> GetRestaurants();
        IRestaurant GetRestaurant(int id);
    }
}