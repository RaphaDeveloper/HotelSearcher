﻿using System;

namespace Domain.Hotels.ValueObjects
{
	public class Price
	{
		public Price(decimal forWeekDay, decimal forWeekendDay)
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
