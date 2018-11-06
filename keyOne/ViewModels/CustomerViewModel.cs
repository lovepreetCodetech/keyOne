using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using keyOne.Models;

namespace keyOne.ViewModels
{
	public class CustomerViewModel
	{
			public Customer Customers { get; set; }
			public List<Customer> CustomersList { get; set; }
		
	}
}