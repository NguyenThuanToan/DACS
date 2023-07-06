using DACS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class ShoppingCartController : Controller
    {
        public List<CartModel> GetShoppingCartFromSession()
        {
            var listShoppingCart = Session["ShoppingCart"] as List<CartModel>;
            if (listShoppingCart == null)
            {
                listShoppingCart = new List<CartModel>();
                Session["ShoppingCart"] = listShoppingCart;
            }
            return listShoppingCart;
        }
        // GET: ShoppingCart
        [Authorize]
        public ActionResult Index()
        {
            List<CartModel> ShoppingCart = GetShoppingCartFromSession();
            if (ShoppingCart.Count == 0)
                return RedirectToAction("Index", "Product");
            ViewBag.TongSoLuong = ShoppingCart.Sum(p => p.Quantity);
            ViewBag.TongTien = ShoppingCart.Sum(p => p.Quantity * p.Price);
            return View(ShoppingCart);
        }
        [Authorize]
        public RedirectToRouteResult AddToCart(int id)
        {
            DACSModelContext db = new DACSModelContext(); 
            List<CartModel> ShoppingCart = GetShoppingCartFromSession();
            CartModel findCardItem = ShoppingCart.FirstOrDefault(m => m.IdProduct == id);
            if (findCardItem == null)
            {
                Product findProduct = db.Products.First(m => m.IdProduct == id);
                CartModel newItem = new CartModel()
                {
                    IdProduct = findProduct.IdProduct,
                    NameProduct = findProduct.NameProduct,
                    Quantity = 1,
                    ImageProduct = findProduct.ImageProduct,
                    Price = findProduct.Price.Value
                };
                ShoppingCart.Add(newItem);
            }
            else
                findCardItem.Quantity++;
            return RedirectToAction("Index", "ShoppingCart");
        }
        


        public RedirectToRouteResult UpdateCart(int id, int txtQuantity)
        {
            var itemFind = GetShoppingCartFromSession().FirstOrDefault(p => p.IdProduct == id);
            if (itemFind != null)
                itemFind.Quantity = txtQuantity;
            return RedirectToAction("Index");
        }
        public ActionResult CartSummary()
        {
            ViewBag.CartCount = GetShoppingCartFromSession().Count();
            return PartialView("CartSummary");
        }
        [Authorize]
        public ActionResult Order()
        {
            string currentUserId = User.Identity.GetUserId();
            DACSModelContext db = new DACSModelContext();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Order objOrder = new Order()
                    {
                        CustomerId = null,
                        OrderDate = DateTime.Now,
                        DeliveryDate = null,
                        isPaid = false,
                        isComplete = false
                    };
                    objOrder = db.Orders.Add(objOrder);
                    db.SaveChanges();

                    List<CartModel> listCartModels = GetShoppingCartFromSession();
                    foreach (var item in listCartModels)
                    {
                        OrderDetail ctdh = new OrderDetail()
                        {
                            OrderNo = objOrder.OrderNo,
                            IdProduct = item.IdProduct,
                            Quantity = item.Quantity,
                            Price = item.Price,
                        };
                        db.OrderDetails.Add(ctdh);
                        db.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Content("Đặt hàng thành công vui lòng đợi vài phút , shipper sẽ vận chuyển đến nhà bạn ngay" + ex.Message);
                }
            }
            Session["Giohang"] = null;
            return RedirectToAction("ConfirmOrder", "ShoppingCart");
        }
        public ActionResult ConfirmOrder()
        {
            return View();
        }
        public RedirectToRouteResult RemoveCartItem(int id)
        {
            var itemFind = GetShoppingCartFromSession().FirstOrDefault(p => p.IdProduct == id);
            GetShoppingCartFromSession().Remove(itemFind);
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult Delete()
        {
            List<CartModel> ShoppingCart = GetShoppingCartFromSession();
            ShoppingCart.Clear();
            return RedirectToAction("Index");
        }
    }
}