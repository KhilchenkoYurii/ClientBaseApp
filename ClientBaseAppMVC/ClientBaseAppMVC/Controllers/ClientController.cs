using ClientBaseAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ClientBaseAppMVC.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClientBaseAppMVC.Controllers
{
    public class ClientController : Controller
    {

        private readonly MongoDbContext _context;

        public ClientController(IOptions<ClientsDatabaseSettings> settings)
        {
            _context = new MongoDbContext(settings);
        }

        public IActionResult Index()
        {
            List<Client> objList = _context.Clients;

            return View(objList);
        }
    }
}
