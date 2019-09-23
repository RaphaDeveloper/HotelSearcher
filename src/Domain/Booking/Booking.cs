using System;
using System.Collections.Generic;

namespace Domain
{
	public class Booking
	{
		public Booking(Hotel hotel, Costumer costumer, IEnumerable<DateTime> dates)
		{
			Hotel = hotel;
			Costumer = costumer;
			Dates = dates;
		}

		public Hotel Hotel { get; }
		public Costumer Costumer { get; }
		public IEnumerable<DateTime> Dates { get; }
	}
}
