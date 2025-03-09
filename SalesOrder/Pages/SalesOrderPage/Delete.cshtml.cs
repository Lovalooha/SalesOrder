using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesOrder.Services;

namespace SalesOrder.Pages.SalesOrderPage
{
    public class DeleteModel : PageModel
    {
		private readonly ApplicationDbContext _context;
		public DeleteModel(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> OnGet(long id)
        {
			var order = await _context.SO_ORDER.FindAsync(id);

			if (order == null)
			{
				return RedirectToPage("/SalesOrderPage/Index");
			}

			var itemsToDelete = _context.SO_ITEM.Where(i => i.SO_ORDER_ID == id).ToList();
			if (itemsToDelete.Any())
			{
				_context.SO_ITEM.RemoveRange(itemsToDelete);
			}

			_context.SO_ORDER.Remove(order);

			await _context.SaveChangesAsync();

			return RedirectToPage("/SalesOrderPage/Index");
		}
    }
}
