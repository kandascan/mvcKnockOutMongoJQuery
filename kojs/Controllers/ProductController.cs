using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kojs.DataAccess;

namespace kojs.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts()
        {
            DataAccess.MongoDB mongo = new DataAccess.MongoDB("ProductsDataBase");

            var products = mongo.GetProducts();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}