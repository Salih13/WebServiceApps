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
    public class UserController : ApiController
    {
        private BlogEntities db = new BlogEntities();

        // GET: api/User
        public IQueryable<Kullanici> GetKullanici()
        {
            return db.Kullanici;
        }

        // GET: api/User/5
        [ResponseType(typeof(Kullanici))]
        public IHttpActionResult GetKullanici(int id)
        {
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return Ok(kullanici);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKullanici(int id, Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kullanici.Id)
            {
                return BadRequest();
            }

            db.Entry(kullanici).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullaniciExists(id))
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

        // POST: api/User
        [HttpPost]
        [ResponseType(typeof(Kullanici))]
        public IHttpActionResult PostKullanici(Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kullanici.Add(kullanici);
            db.SaveChanges();

            return Json("basarili");
        }

        // DELETE: api/User/5
        [ResponseType(typeof(Kullanici))]
        public IHttpActionResult DeleteKullanici(int id)
        {
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return NotFound();
            }

            db.Kullanici.Remove(kullanici);
            db.SaveChanges();

            return Ok(kullanici);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KullaniciExists(int id)
        {
            return db.Kullanici.Count(e => e.Id == id) > 0;
        }
    }
}