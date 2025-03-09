using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SalesOrder.Models;
using SalesOrder.Services;

namespace SalesOrder.Pages.SalesOrderPage
{
    public class IndexModel : PageModel
    {
		private readonly ApplicationDbContext _context;
		public IndexModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<Order>? orderList { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }

		public async Task OnGetAsync()
		{
			orderList = await (from order in _context.SO_ORDER
							   join customer in _context.COM_CUSTOMER on order.COM_CUSTOMER_ID equals customer.COM_CUSTOMER_ID
							   orderby order.SO_ORDER_ID ascending
							   select new Order
							   {
								   SO_ORDER_ID = order.SO_ORDER_ID,
								   ORDER_NO = order.ORDER_NO,
								   ORDER_DATE = order.ORDER_DATE,
								   CUSTOMER_NAME = customer.CUSTOMER_NAME,
								   ADDRESS = order.ADDRESS
							   }).ToListAsync(); 
		}

		public async Task<IActionResult> OnGetExportToExcelAsync()
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			var salesOrders = await _context.SO_ORDER.ToListAsync();

			using (var package = new ExcelPackage())
			{
				var worksheet = package.Workbook.Worksheets.Add("Sales Orders");

				worksheet.Cells[1, 1].Value = "No";
				worksheet.Cells[1, 2].Value = "Sales Order Number";
				worksheet.Cells[1, 3].Value = "Order Date";
				worksheet.Cells[1, 4].Value = "Customer Name";
				worksheet.Cells[1, 5].Value = "Address";

				for (int i = 0; i < salesOrders.Count; i++)
				{
					var order = salesOrders[i];
					worksheet.Cells[i + 2, 1].Value = i + 1; 
					worksheet.Cells[i + 2, 2].Value = order.ORDER_NO;
					worksheet.Cells[i + 2, 3].Value = order.ORDER_DATE.ToString("MM/dd/yyyy");
					worksheet.Cells[i + 2, 4].Value = order.COM_CUSTOMER_ID;  
					worksheet.Cells[i + 2, 5].Value = order.ADDRESS;
				}

				var fileContents = package.GetAsByteArray();

				return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalesOrders.xlsx");
			}
		}

	}

}
