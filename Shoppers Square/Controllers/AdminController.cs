using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoppers_Square.Controllers
{
    public class AdminController : Controller
    {
        //Get:Admin
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(SProduct ProductDetails, HttpPostedFileBase File1)
        {
            using (ShoppersSquareDBContext db = new ShoppersSquareDBContext())
            {
                if (ModelState.IsValid)
                {
                    if (File1 != null && File1.ContentLength > 0)
                    {
                        String ImageName = System.IO.Path.GetFileName(File1.FileName);
                        String ImagePath = Server.MapPath("~/ProductImages/" + ImageName);
                        File1.SaveAs(ImagePath);
                        ProductDetails.ProductImage = ImageName;
                        db.productDetails.Add(ProductDetails);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                }
            }
            return RedirectToAction("ProductList");
            }
        
        public ActionResult ProductList()
        {
            using (ShoppersSquareDBContext db = new ShoppersSquareDBContext())
            {
                return View(db.productDetails.ToList());
            }
        }
        public ActionResult Editlist(int id=0)
        {
            using (ShoppersSquareDBContext db = new ShoppersSquareDBContext())
            {
                SProduct sproduct = db.productDetails.Find(id);
                if(sproduct == null)
                {
                    return HttpNotFound();
                }
                return View(sproduct);
            }
        }

        [HttpPost]
        public ActionResult EditList(SProduct sproduct)
        {
            using (ShoppersSquareDBContext db = new ShoppersSquareDBContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(sproduct).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ProductList");
                }
                return View(sproduct);
            }
        }
        public ActionResult DeleteList(int id=0)
        {
            using (ShoppersSquareDBContext db = new ShoppersSquareDBContext())
            {
                SProduct sproduct = db.productDetails.Find(id);
                if(sproduct == null)
                {
                    return HttpNotFound();
                }
                return View(sproduct);
            }
        }
        [HttpPost, ActionName("DeleteList")]
        public ActionResult DeleteListconfirmed(int id)
        {
            using (ShoppersSquareDBContext db = new ShoppersSquareDBContext())
            {
                SProduct sproduct = db.productDetails.Find(id);
                db.productDetails.Remove(sproduct);
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
        }
    }
}