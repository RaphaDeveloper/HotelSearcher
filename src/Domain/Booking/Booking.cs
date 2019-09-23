using System;
using System.Collections.Generic;

namespace Domain
{
	public class Booking
	{
		public Booking(Hotel hotel, Costumer costumer, IEnumerable<DateTime> dates, decimal totalPrice)
		{
			Hotel = hotel;
			Costumer = costumer;
			Dates = dates;
			TotalPrice = totalPrice;
		}

		public Hotel Hotel { get; }
		public Costumer Costumer { get; }
		public IEnumerable<DateTime> Dates { get; }
		public decimal TotalPrice { get; set; }
	}
}
