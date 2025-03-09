using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesOrder.Models;
using SalesOrder.Services;

namespace SalesOrder.Pages.SalesOrderPage
{
    public class EditModel : PageModel
    {
		[BindProperty]
		public SaveOrder SaveOrder { get; set; } = new SaveOrder();

		private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

		public List<Customer>? customerList { get; set; }

		public async Task<IActionResult> OnGet(long id)
        {
			var order = _context.SO_ORDER.Find(id);
			var items = _context.SO_ITEM.Where(i => i.SO_ORDER_ID == id).ToList();
			customerList = await _context.GetCustomersAsync() ?? new List<Customer>();

			if (order == null)
            {
                return RedirectToPage("/SalesOrderPage/Index");
            }

            SaveOrder.OrderNo = order.ORDER_NO;
            SaveOrder.OrderDate = order.ORDER_DATE;
            SaveOrder.CustomerId = order.COM_CUSTOMER_ID;
            SaveOrder.Address = order.ADDRESS;

			SaveOrder.Items = items.Select(i => new Item
			{
				ITEM_NAME = i.ITEM_NAME,
				QUANTITY = i.QUANTITY,
				PRICE = i.PRICE
			}).ToList();

			return Page();

        }

		public async Task<IActionResult> OnPost(long id)
		{
			customerList = await _context.GetCustomersAsync();

			if (!ModelState.IsValid)
			{
				return Page();
			}

			var order = _context.SO_ORDER.Find(id);
			if (order == null)
			{
				return RedirectToPage("/SalesOrderPage/Index");
			}


			order.ORDER_NO = SaveOrder.OrderNo;
			order.ORDER_DATE = SaveOrder.OrderDate;
			order.COM_CUSTOMER_ID = SaveOrder.CustomerId;
			order.ADDRESS = SaveOrder.Address;

			_context.SO_ORDER.Update(order);
			await _context.SaveChangesAsync();

			var itemsToDelete = _context.SO_ITEM.Where(i => i.SO_ORDER_ID == id).ToList();
			_context.SO_ITEM.RemoveRange(itemsToDelete);
			await _context.SaveChangesAsync();

			foreach (var item in SaveOrder.Items)
			{
				var newItem = new Item
				{
					SO_ORDER_ID = order.SO_ORDER_ID,
					ITEM_NAME = item.ITEM_NAME,
					QUANTITY = item.QUANTITY,
					PRICE = item.PRICE
				};
				_context.SO_ITEM.Add(newItem);
			}

			await _context.SaveChangesAsync();

			return RedirectToPage("/SalesOrderPage/Index");
		}

	}
}
