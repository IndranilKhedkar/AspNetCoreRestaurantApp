using AspNetCoreRestaurantApp.Services.Enums;

namespace AspNetCoreRestaurantApp.Services.Interfaces
{
    public interface IRestaurant
    {
        int Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        CuisineType Cuisine { get; set; }
    }
}