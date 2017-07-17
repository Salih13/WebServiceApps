using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ArticleController : ApiController
    {
        private BlogEntities db = new BlogEntities();

        // GET: api/Article
        public IEnumerable<Makale> GetMakale()
        {           
            return db.Makale.ToList();
        }

        // GET: api/Article/5
        [ResponseType(typeof(Makale))]
        public IHttpActionResult GetMakale(int id)
        {
            Makale makale = db.Makale.Find(id);
            if (makale == null)
            {
                return NotFound();
            }

            return Ok(makale);
        }

        // PUT: api/Article/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMakale(string id, Makale makale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != makale.Baslik)
            {
                return BadRequest();
            }

            db.Entry(makale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakaleExists(id))
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

        // POST: api/Article
        [ResponseType(typeof(Makale))]
        public IHttpActionResult PostMakale(Makale makale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Makale.Add(makale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MakaleExists(makale.Baslik))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Json("basarili");
        }

        // DELETE: api/Article/5
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult DeleteMakale(int id)
        {
            Makale makale = db.Makale.Find(id);
            if (makale == null)
            {
                return NotFound();
            }

            db.Makale.Remove(makale);
            db.SaveChanges();

            return Ok(makale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MakaleExists(string id)
        {
            return db.Makale.Count(e => e.Baslik == id) > 0;
        }
    }
}