using DACS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class CategoryController : Controller
    {
        DACSModelContext objModel = new DACSModelContext();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objModel.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objModel.Products.Where(n => n.IdCategory == Id).ToList();
            return View(listProduct);
        }
    }
}