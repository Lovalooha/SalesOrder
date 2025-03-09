using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Models;
using SalesOrder.Services;

namespace SalesOrder.Pages.SalesOrderPage
{
	public class CreateModel : PageModel
	{

		private readonly ApplicationDbContext _context;
		public CreateModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<Customer>? customerList { get; set; }

		public async Task OnGetAsync()
		{
			customerList = await _context.GetCustomersAsync();
		}
		[BindProperty]
		public SaveOrder SaveOrder { get; set; } = new();

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}


			var saveOrder = new NewOrder
			{
				ORDER_NO = SaveOrder.OrderNo,
				ORDER_DATE = SaveOrder.OrderDate,
				COM_CUSTOMER_ID = SaveOrder.CustomerId,
				ADDRESS = SaveOrder.Address
			};

			_context.SO_ORDER.Add(saveOrder);
			await _context.SaveChangesAsync(); 

			long soOrderId = saveOrder.SO_ORDER_ID;

			foreach (var item in SaveOrder.Items)
			{
				var soItem = new Item
				{
					SO_ORDER_ID = soOrderId,
					ITEM_NAME = item.ITEM_NAME,
					QUANTITY = item.QUANTITY,
					PRICE = item.PRICE
				};
				_context.SO_ITEM.Add(soItem); 
			}
			await _context.SaveChangesAsync(); 
			return RedirectToPage("/SalesOrderPage/Index"); 
		}

	}
}
