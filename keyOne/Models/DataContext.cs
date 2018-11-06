using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace keyOne.Models
{
	public class DataContext: DbContext
	{
	
		public DbSet<Customer> Customers { get; set;}
		public DbSet<Product> Products { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Sale> Sales { get; set; }


	}
}