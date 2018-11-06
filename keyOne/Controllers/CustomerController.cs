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

	public class CustomerController : Controller
	{
		private DataContext db = new DataContext();
		// GET: Customer
		public ActionResult Index()
		{
			var Data=new CustomerViewModel()
				{
				CustomersList = db.Customers.ToList()
			};
				

			return View(Data);
		}
		[HttpPost]
		public ActionResult Index(CustomerViewModel cust)
		{
			
			if (cust.Customers.CustomerId > 0)
			{
				var name = cust.Customers.CustomerName;
				Customer customer = db.Customers.Where(c => c.CustomerName == name).SingleOrDefault();
				if (customer != null && cust.Customers.CustomerId != customer.CustomerId)
				{
					return Json(false);
				}
				Customer cus = db.Customers.Where(a => a.CustomerId == cust.Customers.CustomerId).SingleOrDefault();
				cus.CustomerName = cust.Customers.CustomerName;
				cus.CustomerAddress = cust.Customers.CustomerAddress;
				db.SaveChanges();
			}
			else
			{
				var name = cust.Customers.CustomerName;
				Customer customer = db.Customers.Where(c => c.CustomerName == name).SingleOrDefault();
				if (customer != null)
				{
					return Json(false);
				}
				Customer cse = new Customer()
				{
					CustomerName = cust.Customers.CustomerName,
					CustomerAddress = cust.Customers.CustomerAddress
				};
				db.Customers.Add(cse);
				db.SaveChanges();
			}
			
			return RedirectToAction("Index");
		}
		public ActionResult DeleteCustomer(int CustomerId)
		{
			bool result = false;
			Customer cu = db.Customers.SingleOrDefault(x => x.CustomerId == CustomerId);
			if (cu != null)
			{
				db.Customers.Remove(cu);
				db.SaveChanges();
				result = true;
			}
			return Json(result, JsonRequestBehavior.AllowGet);

		}
		public ActionResult EditCustomer(int customerId)
		{
			Customer customer = db.Customers.Where(c => c.CustomerId == customerId).SingleOrDefault();
			CustomerViewModel model = new CustomerViewModel()
			{
				Customers = customer
			};
			return PartialView("EditPartial", model);
		}
	}

}
