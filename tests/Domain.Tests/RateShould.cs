using NUnit.Framework;
using System;

namespace Domain.Tests
{
	public class RateShould
	{
		private Price rate;

		[SetUp]
		public void Setup()
		{
			rate = new Price(110, 90);
		}

		[Test]
		public void Return_Rate_For_Week_Day()
		{
			DateTime friday = new DateTime(2019, 09, 13);

			decimal rateForWeekDay = rate.GetByDate(friday);

			Assert.AreEqual(110, rateForWeekDay);
		}

		[Test]
		public void Return_Rate_For_Weekend_Day()
		{
			DateTime saturday = new DateTime(2019, 09, 14);

			decimal rateForWeekendDay = rate.GetByDate(saturday);

			Assert.AreEqual(90, rateForWeekendDay);
		}
	}
}
