using AspNetCoreRestaurantApp.Services.Implementation;
using AspNetCoreRestaurantApp.Services.Interfaces;
using System.Collections.Generic;

namespace AspNetCoreRestaurantApp.Services.Repository
{
    public static class RestaurantRepository
    {
        public static List<IRestaurant> _restaurants;
        public static List<IRestaurant> GetRestaurants()
        {
            return _restaurants = new List<IRestaurant>()
            {
                new Restaurant() { Id=1, Name="Indranil's Pizza Place"},
                new Restaurant() { Id=2, Name="Hotel Buhari"},
                new Restaurant() { Id=3, Name="Paradise Biryani"},
                new Restaurant() { Id=4, Name="Absolute Barbeque"},
                new Restaurant() { Id=5, Name="Barbeque Nation"}
            };
        }
    }
}
