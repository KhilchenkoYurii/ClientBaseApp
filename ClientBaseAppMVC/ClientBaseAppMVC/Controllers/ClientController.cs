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
            if (ModelState.IsValid)
            {
                IMongoCollection<Client> mongoCollection = _context.Clients;
                mongoCollection.InsertOne(obj);
            }
                return RedirectToAction("Index");
        }

        public IActionResult Edit(string? id)
        {
            if(id == null || id == "")
            {
                return NotFound();
            }

            Client clientFromDb = _context.Clients.AsQueryable().Where(element=>element.Id==id).FirstOrDefault();
            if (clientFromDb == null)
            {
                return NotFound();
            }

            return View(clientFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Client obj)
        {
            if (ModelState.IsValid)
            {
                IMongoCollection<Client> mongoCollection = _context.Clients;
                var filter = Builders<Client>.Filter.Eq(element=>element.Id, obj.Id);
                mongoCollection.ReplaceOne(filter, obj);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }

            Client clientFromDb = _context.Clients.AsQueryable().Where(element => element.Id == id).FirstOrDefault();
            if (clientFromDb == null)
            {
                return NotFound();
            }

            return View(clientFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(string? id)
        {
            if(id == null || id == "")
            {
                return NotFound();
            }
            Client clientFromDb = _context.Clients.AsQueryable().Where(element => element.Id == id).FirstOrDefault();
            
            if (clientFromDb == null)
            {
                return NotFound();
            }
            IMongoCollection<Client> mongoCollection = _context.Clients;
            var filter = Builders<Client>.Filter.Eq(element=>element.Id, id);
            mongoCollection.DeleteOne(item=>item.Id == id);
            return RedirectToAction("Index");
        }
    }
}
