using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candle.DATA.EF.Models
{
	//internal class Partials
	//{
	//}
	[ModelMetadataType(typeof(CategoryMetadata))]
	public partial class Category { }

	[ModelMetadataType(typeof(OrdersMetadata))]
	public partial class Order { }

	[ModelMetadataType(typeof(ProductsMetadata))]
	public partial class Product { }

	[ModelMetadataType(typeof(UserDetailsMetadata))]
	public partial class UserDetail 
	{
		//public string FullName => FirstName + " " + LastName;
	}
	
}
