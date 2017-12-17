using AspNetCoreRestaurantApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRestaurantApp.Pages
{
    public class GreetingsModel : PageModel
    {
        private IGreeter _greeter;
        public string greetings { get; set; }

        public GreetingsModel(IGreeter greeter)
        {
            _greeter = greeter;
        }
        public void OnGet(string name)
        {
            greetings = $"{name}: {_greeter.GetMessageOfTheDay()}";
        }
    }
}