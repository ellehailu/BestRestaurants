using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
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

        public ActionResult Edit(int id)
        {
            Restaurant foundRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
            return View(foundRestaurant);
        }

        [HttpPost]
        public ActionResult Edit (Restaurant restaurant)
        {
        _db.Restaurants.Update(restaurant);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult Delete(int id){
            Restaurant foundRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            return View(foundRestaurant);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id){
            Restaurant foundRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            _db.Restaurants.Remove(foundRestaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}