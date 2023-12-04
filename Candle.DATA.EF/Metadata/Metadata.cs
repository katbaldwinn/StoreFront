using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candle.DATA.EF.Models
{
	//internal class Metadata
	//{
	//}

	public class CategoryMetadata
	{
		[Display(Name = "Category")]
		[StringLength(50)]
		public string CategoryName { get; set; } = null!;

		[Display(Name = "Description")]
		[StringLength(50)]
		[DisplayFormat(NullDisplayText = "[N/A]")]
		[UIHint("MultilineText")]
		public string? CategoryDescription { get; set; }
	}

	public class OrdersMetadata
	{
		[Display(Name = "Delivery or pickup")]
		public bool IsDelivery { get; set; }

		[Display(Name = "Order Date")]
		[DataType(DataType.DateTime)]
		public DateTime OrderPlaced { get; set; }
	}

	public class ProductsMetadata
	{
		[DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
		[Display(Name = "Price")]
		[DataType(DataType.Currency)]
		[DefaultValue(0)]
		[Range(0, (double)decimal.MaxValue)]
		public decimal ProductPrice { get; set; }

		[Display(Name = "Product")]
		[StringLength(500)]
		public string ProductName { get; set; } = null!;

		[Display(Name = "Description")]
		[DisplayFormat(NullDisplayText = "[N/A]")]
		[StringLength(1000)]
		[UIHint("MultilineText")]
		public string? ProductDescription { get; set; }

		[Display(Name = "Status")]
		public int StatusId { get; set; }

		[Display(Name = "Image")]
		[DisplayFormat(NullDisplayText = "[N/A]")]
		[StringLength(75)]
		public string? ProductImage { get; set; }

	}

	public class UserDetailsMetadata
	{
		[DisplayFormat(NullDisplayText = "[N/A]")]
		[StringLength(100)]
		[Display(Name = "Username")]
		public string? UserName { get; set; }

		[DisplayFormat(NullDisplayText = "[N/A]")]
		[StringLength(100)]
		public string? Address { get; set; }

		[StringLength(50)]
		public string City { get; set; } = null!;

		[StringLength(2, MinimumLength = 2)]
		public string State { get; set; } = null!;

		[StringLength(5, MinimumLength = 5)]
		[DataType(DataType.PostalCode)]
		public string Zip { get; set; } = null!;

		[DataType(DataType.PhoneNumber)]
		[StringLength(24)]
		public string? Phone { get; set; }

		[DataType(DataType.EmailAddress)]
		[StringLength(50)]
		public string? Email { get; set; }
	}

	//public class StockStatus
	//{

	//}
}
