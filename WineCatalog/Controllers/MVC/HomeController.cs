using System.Web.Mvc;

namespace WineCatalog.Controllers.MVC
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Wine
        //public ActionResult Wine()
        //{
        //    return PartialView();
        //}

        //public ActionResult WineVM()
        //{
        //    var model = new WineIndexVM();

        //    using (var db = new WineContext())
        //    {
        //        model.Wines = db.Wines.ToList();
        //    }

        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    using (var db = new WineContext())
        //    {
        //        var wine = id.HasValue ? db.Wines.First(w => w.Id == id.Value) : new Wine();

        //        var model = new Wine()
        //        {
        //            Id = wine.Id,
        //            Name = wine.Name,
        //            Color = wine.Color,
        //            Price = wine.Price,
        //            InStock = wine.InStock
        //        };

        //        db.Entry(model).State = EntityState.Modified;
        //        db.SaveChanges();

        //        return Json(model, JsonRequestBehavior.AllowGet);
        //    }
        //}

        /// <summary>
        /// Add new wine
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult Edit(Wine model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new WineContext())
        //        {
        //            var wine = new Wine()
        //            {
        //                Name = model.Name,
        //                Color = model.Color,
        //                Price = model.Price,
        //                InStock = model.InStock
        //            };

        //            db.Wines.Add(wine);
        //            db.SaveChanges();

        //            return Json(wine, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    throw new HttpException(400, "There were errors in your model.");
        //}

        /// <summary>
        /// Delete wine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public ActionResult Delete(int id)
        //{
        //    using (var db = new WineContext())
        //    {
        //        var existing = db.Wines.FirstOrDefault(w => w.Id == id);
        //        if (existing != null)
        //        {
        //            db.Wines.Remove(existing);
        //            db.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

        public ActionResult ModalTemplate()
        {
            return PartialView();
        }

    }
}
