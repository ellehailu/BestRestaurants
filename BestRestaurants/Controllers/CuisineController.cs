using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;




namespace BestRestaurants.Controllers{
    public class CuisineController : Controller{
        private readonly BestRestaurantsContext _db;
        public CuisineController(BestRestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Cuisine> model = _db.Cuisines.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuisine cuisine)
        {
            _db.Cuisines.Add(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id){
            Cuisine thisCuisine = _db.Cuisines.Include(cuisine => cuisine.Restaurants).FirstOrDefault(cuisine => cuisine.CuisineId == id);
            return View(thisCuisine);
        }
    }
}