using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
	public class SaveOrder
	{
		[Required]
		public string OrderNo { get; set; } = "";
		public DateTime OrderDate { get; set; }

		public int CustomerId { get; set; }

		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; } =  "";
		
		public List<Item> Items { get; set; }
	}
}
