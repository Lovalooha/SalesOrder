﻿using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
	public class Customer
	{
		[Key]
		public int COM_CUSTOMER_ID { get; set; }
		public string CUSTOMER_NAME { get; set; }
	}
}
