using Domain.Customers.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Hotels.Entities
{
	public class Booking
	{
		public Booking(Hotel hotel, Customer customer, IEnumerable<DateTime> dates, decimal totalPrice)
		{
			Hotel = hotel;
			Customer = customer;
			Dates = dates;
			TotalPrice = totalPrice;
		}

		public Hotel Hotel { get; }
		public Customer Customer { get; }
		public IEnumerable<DateTime> Dates { get; }
		public decimal TotalPrice { get; set; }
	}
}
