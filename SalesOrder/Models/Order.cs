using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
	public class Order
	{
		[Key]
		public long SO_ORDER_ID { get; set; }
		public string ORDER_NO { get; set; }
		public DateTime ORDER_DATE { get; set; }
		public int COM_CUSTOMER_ID { get; set; }
		public string ADDRESS { get; set; }
		public string CUSTOMER_NAME { get; set; }

	}
}
