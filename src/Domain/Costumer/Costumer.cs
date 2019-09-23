using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
	public class Costumer
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string Email { get; set; }
		public CostumerType CostumerType { get; set; }
		public List<Booking> Bookings { get; set; } = new List<Booking>();

		internal bool IsValid => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email);

		internal void AddBooking(Booking booking)
		{
			Bookings.Add(booking);
		}

		internal bool IsThereAnyBookingForTheDates(IEnumerable<DateTime> dates)
		{
			if (Bookings.Any())
			{
				Dictionary<DateTime, Booking> bookingByDate = IndexBookingsByDate();

				foreach (var date in dates)
				{
					if (bookingByDate.ContainsKey(date))
					{
						return true;
					}
				}
			}

			return false;
		}

		private Dictionary<DateTime, Booking> IndexBookingsByDate()
		{
			Dictionary<DateTime, Booking> bookingByDate = new Dictionary<DateTime, Booking>();

			foreach (var booking in Bookings)
			{
				foreach (var date in booking.Dates)
				{
					bookingByDate.Add(date, booking);
				}
			}

			return bookingByDate;
		}
	}
}
