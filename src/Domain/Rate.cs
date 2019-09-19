using System;

namespace Domain
{
	public class Rate
	{
		public Rate(decimal forWeekDay, decimal forWeekendDay)
		{
			ForWeekDay = forWeekDay;
			ForWeekendDay = forWeekendDay;
		}

		private decimal ForWeekDay { get; set; }
		private decimal ForWeekendDay { get; set; }

		public decimal GetByDate(DateTime date)
		{
			if (IsWeekendDay(date))
			{
				return ForWeekendDay;
			}

			return ForWeekDay;
		}

		private static bool IsWeekendDay(DateTime date)
		{
			return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
		}
	}
}
