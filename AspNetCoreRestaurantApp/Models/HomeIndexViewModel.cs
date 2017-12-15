using AspNetCoreRestaurantApp.Services.Interfaces;
using System.Collections.Generic;

namespace AspNetCoreRestaurantApp.Models
{
    public class HomeIndexViewModel
    {
        public string MessageOfTheDay { get; set;}
        public List<RestaurantViewModel> Restaurants { get; set; }
    }
}
