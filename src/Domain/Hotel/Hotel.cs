using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
	public class Hotel
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public Dictionary<CostumerType, Price> PriceByCostumerType { get; set; }
		public int Rating { get; set; }
		public List<Booking> Bookings { get; set; } = new List<Booking>();


		public bool IsCheaperThan(Hotel anotherHotel, IHotelSearchCriteria hotelSearchCriteria)
		{
			decimal totalPriceOfThisHotel = CalculateTotalPrice(hotelSearchCriteria);
			decimal totalPriceOfTheAnotherHotel = anotherHotel.CalculateTotalPrice(hotelSearchCriteria);

			if (totalPriceOfThisHotel == totalPriceOfTheAnotherHotel)
			{
				return Rating > anotherHotel.Rating;
			}

			return totalPriceOfThisHotel < totalPriceOfTheAnotherHotel;
		}

		private decimal CalculateTotalPrice(IHotelSearchCriteria hotelSearchCriteria)
		{
			decimal totalPrice = 0;

			foreach (var date in hotelSearchCriteria.Dates)
			{
				totalPrice += GetPrice(hotelSearchCriteria.CostumerType, date);
			}

			return totalPrice;
		}

		private decimal GetPrice(CostumerType costumerType, DateTime date)
		{
			Price price = PriceByCostumerType[costumerType];

			return price.GetByDate(date);
		}


		internal void Book(Costumer costumer, IEnumerable<DateTime> dates)
		{
			if (!costumer.IsThereAnyBookingForTheDates(dates))
			{
				Booking booking = new Booking(this, costumer, dates);

				Bookings.Add(booking);
				costumer.AddBooking(booking);
			}
		}
	}
}
