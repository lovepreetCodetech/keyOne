using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace keyOne.Models
{
	public class Product
	{
		[Key]
		public int ProcductId { get; set; }
		[Required(ErrorMessage ="Please Enter the Required ProductName")]
		[StringLength(255)]
		public string ProcductName { get; set; }
		[Required]
		public double ProcductPrice { get; set; }
	}
}