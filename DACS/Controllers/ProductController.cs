using DACS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.Ajax.Utilities;
using PagedList.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using System.Web.UI;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography;
using System.Drawing.Printing;


namespace DACS.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult Details(int id)
        {
            DACSModelContext objModel = new DACSModelContext();
            var objProduct = objModel.Products.Where(n => n.IdProduct == id).FirstOrDefault();

            var lstCategory = objModel.Categories.ToList();
            var lstProduct = objModel.Products.Where(n => n.IdCategory == objProduct.IdCategory).ToList();

            ProductDetailModel objProductDetailModel = new ProductDetailModel();
            objProductDetailModel.objProduct = objProduct;
            objProductDetailModel.ListCategory = lstCategory;
            objProductDetailModel.ListProduct = lstProduct;
            return View(objProductDetailModel);
        }
        public ActionResult Index1(int ?page)
      {
            DACSModelContext objModel = new DACSModelContext();
            int pageSize = 8;
            int pageNumber = (page ??1);
            var product = objModel.Products.Include(p => p.Category);
            return View(product.ToList().ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Danhmuc1(int? page, int id)
        {
            DACSModelContext objModel = new DACSModelContext();
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var product = objModel.Products.Include(p => p.Category).Where(p => p.IdCategory == id);
            return View(product.ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetProductByCategory(int id)
        {
            DACSModelContext objModel = new DACSModelContext();
            var context = new DACSModelContext();
            return Danhmuc1(1,id);
        }
        public ActionResult GetCategory()
        {
            DACSModelContext objModel = new DACSModelContext();
            var listCategory = objModel.Categories.ToList();
            return PartialView(listCategory);
        }
        
        public ActionResult Search(string searchString)
        {
            DACSModelContext objModel = new DACSModelContext();
            var result = (from m in objModel.Products
                          where m.NameProduct.Contains(searchString)
                          select m);
            if (result.Count() > 0)
                return View("Index1", result.ToList().ToPagedList(1,1));
            return HttpNotFound("Không tìm thấy sản phẩm");
        }
    }
}