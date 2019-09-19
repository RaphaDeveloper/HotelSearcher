using System;
using System.Collections.Generic;

namespace Domain
{
	public class Hotel
	{
		public string Name { get; set; }
		public Dictionary<CostumerType, Rate> RateByCostumerType { get; set; }
		public int Rating { get; set; }

		public bool IsCheaperThan(Hotel anotherHotel, IHotelSearchCriteria hotelSearchCriteria)
		{
			decimal totalRateOfThisHotel = CalculateTotalRate(hotelSearchCriteria);
			decimal totalRateOfAnotherHotel = anotherHotel.CalculateTotalRate(hotelSearchCriteria);

			if (totalRateOfThisHotel == totalRateOfAnotherHotel)
			{
				return Rating > anotherHotel.Rating;
			}

			return totalRateOfThisHotel < totalRateOfAnotherHotel;
		}

		private decimal CalculateTotalRate(IHotelSearchCriteria hotelSearchCriteria)
		{
			decimal totalRate = 0;

			foreach (var date in hotelSearchCriteria.Dates)
			{
				totalRate += GetRate(hotelSearchCriteria.CostumerType, date);
			}

			return totalRate;
		}

		private decimal GetRate(CostumerType costumerType, DateTime date)
		{
			Rate rate = RateByCostumerType[costumerType];

			return rate.GetByDate(date);
		}
	}
}
