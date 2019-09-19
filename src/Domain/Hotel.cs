using System;
using System.Collections.Generic;

namespace Domain
{
	public class Hotel
	{
		public string Name { get; set; }
		public Dictionary<CostumerType, Price> PriceByCostumerType { get; set; }
		public int Rating { get; set; }

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
	}
}
