using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesOrder.Models;
using System.Data;

namespace SalesOrder.Services
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Order> Orders { get; set; }
		public DbSet<NewOrder> SO_ORDER { get; set; }
		public DbSet<Item> SO_ITEM { get; set; }
		public DbSet<Customer> COM_CUSTOMER { get; set; }
		public async Task<List<Customer>> GetCustomersAsync()
		{
			var customers = await this.COM_CUSTOMER
				.FromSqlRaw("EXEC GET_LIST_CUSTOMER")
				.ToListAsync();

			return customers;
		}

	}
}
