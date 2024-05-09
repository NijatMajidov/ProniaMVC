using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
