using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using keyOne.Models;
using keyOne.ViewModels;

namespace keyOne.Controllers
{
	public class StoreController : Controller
	{
		private DataContext db = new DataContext();

		// GET: Store
		public ActionResult Index()
		{
			var Data = new StoreViewModel()
			{
				StoreList = db.Stores.ToList()
			};

			return View(Data);
		}
		[HttpPost]
		public ActionResult Index(StoreViewModel model)
		{
			if (model.Stores.StoreId > 0)
			{
				Store sto = db.Stores.Where(c => c.StoreId == model.Stores.StoreId).SingleOrDefault();
				sto.StoreName = model.Stores.StoreName;
				sto.StoreAddress = model.Stores.StoreAddress;
				db.SaveChanges();
			}
			else
			{
				Store store = new Store();
				store.StoreName = model.Stores.StoreName;
				store.StoreAddress = model.Stores.StoreAddress;
				db.Stores.Add(store);
				db.SaveChanges();
			}

			return RedirectToAction("Index");
		}
		public ActionResult DeleteStore(int storeId)
		{
			bool result = false;
			Store store = db.Stores.SingleOrDefault(x => x.StoreId == storeId);
			if (store != null)
			{
				db.Stores.Remove(store);
				db.SaveChanges();
				result = true;
			};
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult EditStore(int storeId)
		{

			Store store = db.Stores.Where(c => c.StoreId == storeId).SingleOrDefault();
			StoreViewModel model = new StoreViewModel()
			{
				Stores = store
			};
			return PartialView("EditStorePartialView", model);
		}
	

		// GET: Stores/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Store store = db.Stores.Find(id);
			if (store == null)
			{
				return HttpNotFound();
			}
			return View(store);
		}

		// GET: Stores/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Stores/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Address,IsDeleted")] Store store)
		{
			if (ModelState.IsValid)
			{
				db.Stores.Add(store);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(store);
		}

		// GET: Stores/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Store store = db.Stores.Find(id);
			if (store == null)
			{
				return HttpNotFound();
			}
			return View(store);
		}

		// POST: Stores/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Address,IsDeleted")] Store store)
		{
			if (ModelState.IsValid)
			{
				db.Entry(store).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(store);
		}

		// GET: Stores/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Store store = db.Stores.Find(id);
			if (store == null)
			{
				return HttpNotFound();
			}
			return View(store);
		}

		// POST: Stores/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Store store = db.Stores.Find(id);
			db.Stores.Remove(store);
			db.SaveChanges();
			return RedirectToAction("Index");
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
