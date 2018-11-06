using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace keyOne.Models
{
	
	public class Customer
	{
		
		
		public int CustomerId { get; set; }
		[Required(ErrorMessage ="Name is Required")]
		[StringLength(255)]
		public string CustomerName { get; set; }
		[Required(ErrorMessage ="Address is Required")]
		public string CustomerAddress { get; set; }

		
	}
}