using AspNetCoreRestaurantApp.Services.Enums;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreRestaurantApp.Models
{
    public class RestaurantEditModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Restaurant name should contain minimum 2 charecters")]
        [MaxLength(25, ErrorMessage = "Restaurant name should contain maximum 25 charecters")]
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }

        [Required]
        public CuisineType CuisineType { get; set;}

        [Required]
        [Display(Name = "Restaurant Address")]
        [MinLength(5)]
        public string Address { get; set; }
    }
}
