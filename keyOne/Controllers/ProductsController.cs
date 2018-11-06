using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using keyOne.Models;
using keyOne.ViewModels;

namespace keyOne.Controllers
{
    public class ProductsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Products
        public ActionResult Index()
		{
			var Data = new ProductViewModel()
			{
				ProductList = db.Products.ToList()
			};

			return View(Data);
		}
		[HttpPost]
		public ActionResult Index(ProductViewModel model)
		{
			if (model.Products.ProcductId > 0)
			{
				Product pro = db.Products.Where(c => c.ProcductId == model.Products.ProcductId).SingleOrDefault();
				pro.ProcductName = model.Products.ProcductName;
				pro.ProcductPrice = model.Products.ProcductPrice;
				db.SaveChanges();
			}
			else
			{
				Product Product = new Product();
				Product.ProcductName = model.Products.ProcductName;
				Product.ProcductPrice = model.Products.ProcductPrice;
				db.Products.Add(Product);
				db.SaveChanges();
			}

			return RedirectToAction("Index");
		}
		public ActionResult DeleteProduct(int ProcductId)
		{
			bool result = false;
			Product Product = db.Products.SingleOrDefault(x => x.ProcductId == ProcductId);
			if (Product != null)
			{
				db.Products.Remove(Product);
				db.SaveChanges();
				result = true;
			};
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult EditProduct(int ProcductId)
		{

			Product Product = db.Products.Where(c => c.ProcductId == ProcductId).SingleOrDefault();
			ProductViewModel model = new ProductViewModel()
			{
				Products = Product
			};
			return PartialView("EditPartial", model);
		}


		// GET: Product/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product Product = db.Products.Find(id);
			if (Product == null)
			{
				return HttpNotFound();
			}
			return View(Product);
		}

		
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
