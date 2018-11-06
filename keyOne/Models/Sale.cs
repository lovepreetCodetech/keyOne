using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using keyOne.Models;

namespace keyOne.Models
{
	public class Sale
	{
		[Key]
		public int SaleId { get; set; }

		[Required(ErrorMessage = "Customer is required")]
		public int CustomerId { get; set; }

		[Required(ErrorMessage = "Product is required")]
		public int ProductId { get; set; }

		[Required(ErrorMessage = "Store is required")]
		public int StoreId { get; set; }

		[Required(ErrorMessage = "Product sold date is required")]
		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateSold { get; set; }

		public virtual Customer Customers { get; set; }
		public virtual Product Products { get; set; }
		public virtual Store Stores { get; set; }

	}
}