using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreRestaurantApp.Controllers
{
    public class AboutController : Controller
    {
        public string Address()
        {
            return "DLF Chennai, TN 600046";
        }

        public string Phone()
        {
            return "+91-9712345678";
        }
    }
}
