using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineCatalog.EF;
using WineCatalog.Models;

namespace WineCatalog.Controllers
{
    public class HomeController : Controller
    {

        // GET: Wine
        public ActionResult Index()
        {
            ViewBag.Title = "Wine Catalog";

            var model = new WineIndexVM();

            using (var db = new WineContext())
            {
                model.Wines = db.Wines.ToList();
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            Wine wine = null;

            using (var db = new WineContext())
            {
                if (id.HasValue)
                {
                    wine = db.Wines.First(w => w.Id == id.Value);
                }
                else
                {
                    wine = new Wine();
                }

                var model = new Wine()
                {
                    Id = wine.Id,
                    Name = wine.Name,
                    Color = wine.Color,
                    Price = wine.Price,
                    InStock = wine.InStock
                };

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(Wine model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new WineContext())
                {
                    var wine = new Wine()
                    {
                        Name = model.Name,
                        Color = model.Color,
                        Price = model.Price,
                        InStock = model.InStock
                    };

                    db.Wines.Add(wine);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            throw new HttpException(400, "There were errors in your model.");
        }

        public ActionResult Delete(int id)
        {
            using (var db = new WineContext())
            {
                var existing = db.Wines.FirstOrDefault(w => w.Id == id);
                if (existing != null)
                {
                    db.Wines.Remove(existing);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
