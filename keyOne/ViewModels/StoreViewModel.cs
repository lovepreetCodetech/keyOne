using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using keyOne.Models;

namespace keyOne.ViewModels
{
	public class StoreViewModel
	{
		public Store Stores { get; set; }
		public List<Store> StoreList { get; set; }
	}
}