using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace keyOne.Models
{
	public class Store
	{
		public int StoreId { get; set; }
		[Required]
		[StringLength (255)]
		public string StoreName { get; set; }
		[Required]
		public string StoreAddress { get; set; }
	}
}