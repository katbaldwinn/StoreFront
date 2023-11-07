using System;
using System.Collections.Generic;

namespace Candle.DATA.EF.Models
{
	public partial class UserDetail
	{
		public UserDetail()
		{
			Orders = new HashSet<Order>();
		}

		public string UserId { get; set; } = null!;
		public string? UserName { get; set; }
		public string? Address { get; set; }
		public string City { get; set; } = null!;
		public string State { get; set; } = null!;
		public string Zip { get; set; } = null!;
		public string? Phone { get; set; }
		public string? Email { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}
}
