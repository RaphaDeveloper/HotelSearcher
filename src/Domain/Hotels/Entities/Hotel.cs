using Domain.Hotels.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Hotels.Entities
{
	public class Hotel
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public Dictionary<CostumerType, Price> PriceByCostumerType { get; set; }
		public int Rating { get; set; }
		public List<Booking> Bookings { get; set; } = new List<Booking>();


		internal void Book(Costumer costumer, IEnumerable<DateTime> dates)
		{
			if (!costumer.IsThereAnyBookingForTheDates(dates))
			{
				Booking booking = new Booking(this, costumer, dates, CalculateTotalPrice(costumer.CostumerType, dates));

				Bookings.Add(booking);
				costumer.AddBooking(booking);
			}
		}

		public bool IsCheaperThan(Hotel anotherHotel, IHotelSearchCriteria hotelSearchCriteria)
		{
			decimal totalPriceOfThisHotel = CalculateTotalPrice(hotelSearchCriteria.CostumerType, hotelSearchCriteria.Dates);
			decimal totalPriceOfTheAnotherHotel = anotherHotel.CalculateTotalPrice(hotelSearchCriteria.CostumerType, hotelSearchCriteria.Dates);

			if (totalPriceOfThisHotel == totalPriceOfTheAnotherHotel)
			{
				return Rating > anotherHotel.Rating;
			}

			return totalPriceOfThisHotel < totalPriceOfTheAnotherHotel;
		}

		private decimal CalculateTotalPrice(CostumerType costumerType, IEnumerable<DateTime> dates)
		{
			decimal totalPrice = 0;

			foreach (var date in dates)
			{
				totalPrice += GetPrice(costumerType, date);
			}

			return totalPrice;
		}

		private decimal GetPrice(CostumerType costumerType, DateTime date)
		{
			Price price = PriceByCostumerType[costumerType];

			return price.GetByDate(date);
		}
	}
}
