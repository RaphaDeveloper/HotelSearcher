using System;
using System.Collections.Generic;

namespace Domain
{
	public class BookingSpecification
	{
		public BookingSpecification(Guid hotelId, Guid costumerId, IEnumerable<DateTime> dates)
		{
			HotelId = hotelId;
			CostumerId = costumerId;
			Dates = dates;
		}

		public Guid HotelId { get; }
		public Guid CostumerId { get; }
		public IEnumerable<DateTime> Dates { get; }
	}
}
