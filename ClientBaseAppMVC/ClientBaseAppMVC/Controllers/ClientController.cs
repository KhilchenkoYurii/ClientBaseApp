using Microsoft.AspNetCore.Mvc;

namespace ClientBaseAppMVC.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
