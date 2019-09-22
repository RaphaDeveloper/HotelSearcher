using NUnit.Framework;
using System;

namespace Domain.Tests
{
	public class PriceShould
	{
		private Price Price;

		[SetUp]
		public void Setup()
		{
			Price = new Price(110, 90);
		}

		[Test]
		public void Return_Price_For_Week_Day()
		{
			DateTime friday = new DateTime(2019, 09, 13);

			decimal PriceForWeekDay = Price.GetByDate(friday);

			Assert.AreEqual(110, PriceForWeekDay);
		}

		[Test]
		public void Return_Price_For_Weekend_Day()
		{
			DateTime saturday = new DateTime(2019, 09, 14);

			decimal PriceForWeekendDay = Price.GetByDate(saturday);

			Assert.AreEqual(90, PriceForWeekendDay);
		}
	}
}
