using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using keyOne.Models;

namespace keyOne.ViewModels
{
	public class ProductViewModel
	{
		public Product Products { get; set; }
		public List<Product> ProductList { get; set; }
	}
}