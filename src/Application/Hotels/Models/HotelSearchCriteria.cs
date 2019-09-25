using Domain;
using Domain.Customers.ValueObjects;
using Domain.Hotels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Application.Models
{
	public class HotelSearchCriteria : IHotelSearchCriteria
	{
		public CostumerType CostumerType { get; }
		public IEnumerable<DateTime> Dates { get; }

		private HotelSearchCriteria(CostumerType costumerType, IEnumerable<DateTime> dates)
		{
			CostumerType = costumerType;
			Dates = dates;
		}

		public static HotelSearchCriteria CreateFromSerializedCriteria(string serializedCriteria)
		{
			string[] costumerTypeAndDates = serializedCriteria.Split(':');			

			CostumerType CostumerType()
			{
				string costumerType = costumerTypeAndDates[0];

				return Enum.Parse<CostumerType>(costumerType);
			}

			IEnumerable<DateTime> Dates()
			{
				string dates = costumerTypeAndDates[1];

				foreach (string date in dates.Split(','))
				{
					yield return ConvertToDateTime(date);
				}

				DateTime ConvertToDateTime(string date)
				{
					Regex regexToMatchDayBetweenParentheses = new Regex(@"\(([^)]+)\)");

					date = regexToMatchDayBetweenParentheses.Replace(date, "");

					return DateTime.Parse(date);
				}
			}

			return new HotelSearchCriteria(CostumerType(), Dates());
		}
	}
}
