using AspNetCoreRestaurantApp.Services.Enums;
using AspNetCoreRestaurantApp.Services.Interfaces;

namespace AspNetCoreRestaurantApp.Services.Implementation
{
    public class Restaurant : IRestaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
