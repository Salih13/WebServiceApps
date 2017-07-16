using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : ApiController
    {
       private BlogEntities db = new BlogEntities();

        [HttpGet]
        public List<Makale> GetAllMakale()
        {
            return db.Makale.ToList();
        }

        [HttpPost]
        public IHttpActionResult AddMakale(Makale model)
        {
            db.Makale.Add(model);
            db.SaveChanges();

            return Json("basarili");
        }
      
    }
}
