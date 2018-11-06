using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using keyOne.Models;
using keyOne.ViewModels;

namespace keyOne.Controllers
{
	public class SaleController : Controller
	{
		public DataContext db = new DataContext();
		// GET: Sale
		public ActionResult Index()
		{
			var model = new SaleViewModel()
			{
				Customers = db.Customers.ToList(),
				Products = db.Products.ToList(),
				Stores = db.Stores.ToList(),
				SaleList = db.Sales.Include(p => p.Customers).Include(p => p.Products).Include(p => p.Stores).ToList()
			};
			return View(model);
		}

		[HttpPost]
		public ActionResult Index(SaleViewModel model)
		{

			if (model.Sales.SaleId > 0)
			{
				Sale ps = db.Sales.Where(c => c.SaleId == model.Sales.SaleId).SingleOrDefault();
				ps.CustomerId = model.Sales.CustomerId;
				ps.ProductId = model.Sales.ProductId;
				ps.StoreId = model.Sales.StoreId;
				ps.DateSold = model.Sales.DateSold;
				db.SaveChanges();
			}
			else
			{
				Sale ps = new Sale()
				{
					CustomerId = model.Sales.CustomerId,
					ProductId = model.Sales.ProductId,
					StoreId = model.Sales.StoreId,
					DateSold = model.Sales.DateSold
				};

				db.Sales.Add(ps);
				db.SaveChanges();
			}
			return RedirectToAction("Index");
		}


		public ActionResult DeleteSale(int SaleId)
		{
			bool result = false;
			Sale ps = db.Sales.SingleOrDefault(x => x.SaleId == SaleId);
			if (ps != null)
			{
				db.Sales.Remove(ps);
				db.SaveChanges();
				result = true;
			}
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult EditSale(int SaleId)
		{

			Sale ps = db.Sales.Where(c => c.SaleId == SaleId).SingleOrDefault();
			List<Customer> list = db.Customers.ToList();
			ViewBag.CustomerList = new SelectList(list, "CustomerId", "CustomerName");
			List<Product> list2 = db.Products.ToList();
			ViewBag.ProductList = new SelectList(list2, "ProcductId", "ProcductName");
			List<Store> list3 = db.Stores.ToList();
			ViewBag.StoreList = new SelectList(list3, "StoreId", "StoreName");
			SaleViewModel model = new SaleViewModel()
			{
				Sales = ps
			};
			return PartialView("EditSale", model);
		}
	}

}
