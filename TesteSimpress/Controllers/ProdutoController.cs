using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteSimpress.Models;

namespace TesteSimpress.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoDB prodDB = new ProdutoDB();

        CategoriaDB catDB = new CategoriaDB();
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(prodDB.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListCategoria()
        {
            return Json(catDB.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Produto prod)
        {
            return Json(prodDB.AddProd(prod), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            var Product = prodDB.ListAll().Find(x => x.Id.Equals(ID));
            return Json(Product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update( Produto prod)
        {
            return Json(prodDB.UpdateProd(prod), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            return Json(prodDB.DeleteProd(ID), JsonRequestBehavior.AllowGet);
        }
    }
}