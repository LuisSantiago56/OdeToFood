using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
                //return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                //return View("NotFound");
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {

            /** This is one way to do simple validations
             *  Is better use when we need to validate the value of the attribute.
             *  When we only need to enforce the present of the value we can use the [Required]
             *  Annotation added on Restaurant Model as an example
             *  
                if(String.IsNullOrEmpty(restaurant.Name))
                {
                    ModelState.AddModelError(nameof(restaurant.Name), "The Name is required");
                }
            */
            if(ModelState.IsValid)
            {
                db.Add(restaurant);
                //return RedirectToAction("Index");
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View();
        }
    }
}