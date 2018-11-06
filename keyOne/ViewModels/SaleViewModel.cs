using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using keyOne.Models;

namespace keyOne.ViewModels
{
	public class SaleViewModel
	{
		public Sale Sales { get; set; }
		public List<Sale> SaleList { get; set; }
		public IEnumerable<Customer> Customers { get; set; }
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Store> Stores { get; set; }
		

	}
}