using System;
using System.Collections.Generic;

namespace Domain
{
	public class Booking
	{
		public Booking(Costumer costumer, IEnumerable<DateTime> dates)
		{
			Costumer = costumer;
			Dates = dates;
		}

		public Costumer Costumer { get; }
		public IEnumerable<DateTime> Dates { get; }
	}
}
