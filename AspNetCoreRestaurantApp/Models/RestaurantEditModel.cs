using AspNetCoreRestaurantApp.Services.Enums;

namespace AspNetCoreRestaurantApp.Models
{
    public class RestaurantEditModel
    {
        public string Name { get; set; }
        public CuisineType CuisineType { get; set;}
        public string Address { get; set; }
    }
}
