using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantController.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly BestRestaurantsContext _db;

        public RestaurantController(BestRestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Restaurant> model = _db.Restaurants.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            return View(thisRestaurant);
        }


    }
}