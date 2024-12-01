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
            List<Client> objList = _context.Clients.AsQueryable<Client>().ToList<Client>();

            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Client obj)
        {
            IMongoCollection<Client> mongoCollection = _context.Clients;
            mongoCollection.InsertOne(obj);
            return RedirectToAction("Index");
        }
    }
}
