using AspNetCoreRestaurantApp.Services.Enums;

namespace AspNetCoreRestaurantApp.Models
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CuisineType CuisineType { get; set;}
        public string Address { get; set; }
    }
}
