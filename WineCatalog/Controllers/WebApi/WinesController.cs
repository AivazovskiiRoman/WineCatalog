using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WineCatalog.EF;
using WineCatalog.Models;

namespace WineCatalog.Controllers.WebApi
{
    public class WinesController : ApiController
    {
        private WineContext db = new WineContext();

        // GET: api/Wines
        public IQueryable<Wine> GetWines()
        {
            return db.Wines;
        }

        // GET: api/Wines/5
        [ResponseType(typeof(Wine))]
        public IHttpActionResult GetWine(int id)
        {
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return NotFound();
            }

            return Ok(wine);
        }

        // PUT: api/Wines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWine(int id, Wine wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wine.Id)
            {
                return BadRequest();
            }

            db.Entry(wine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Wines
        [ResponseType(typeof(Wine))]
        public IHttpActionResult PostWine(Wine wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wines.Add(wine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wine.Id }, wine);
        }

        // DELETE: api/Wines/5
        [ResponseType(typeof(Wine))]
        public IHttpActionResult DeleteWine(int id)
        {
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return NotFound();
            }

            db.Wines.Remove(wine);
            db.SaveChanges();

            return Ok(wine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WineExists(int id)
        {
            return db.Wines.Count(e => e.Id == id) > 0;
        }
    }
}