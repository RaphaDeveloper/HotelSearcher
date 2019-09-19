using Domain;
using Domain.Tests.Stubs;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
	public class HotelSearcherShould
	{
		private HotelSearcher hotelSearcher;

		[SetUp]
		public void Setup()
		{
			hotelSearcher = new HotelSearcher(new HotelRepository());
		}

		[Test]
		public void Find_The_Cheaper_Hotel_For_Week_Day_To_Regular_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Regular, new DateTime(2019, 09, 09), new DateTime(2019, 09, 13));

			string hotel = hotelSearcher.FindTheCheaperHotel(hotelSearchCriteria);

			Assert.AreEqual("Lakewood", hotel);
		}

		[Test]
		public void Find_The_Cheaper_Hotel_For_Weekend_Day_To_Regular_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Regular, new DateTime(2019, 09, 14), new DateTime(2019, 09, 15));

			string hotel = hotelSearcher.FindTheCheaperHotel(hotelSearchCriteria);

			Assert.AreEqual("Bridgewood", hotel);
		}

		[Test]
		public void Find_The_Cheaper_Hotel_For_Week_Day_And_Weekend_Day_To_Regular_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Regular, new DateTime(2019, 09, 13), new DateTime(2019, 09, 14));

			string hotel = hotelSearcher.FindTheCheaperHotel(hotelSearchCriteria);

			Assert.AreEqual("Lakewood", hotel);
		}

		[Test]
		public void Find_The_Cheaper_Hotel_For_Week_Day_To_Reward_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Reward, new DateTime(2019, 09, 09), new DateTime(2019, 09, 13));

			string hotel = hotelSearcher.FindTheCheaperHotel(hotelSearchCriteria);

			Assert.AreEqual("Lakewood", hotel);
		}

		[Test]
		public void Find_The_Cheaper_Hotel_For_Weekend_Day_To_Reward_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Reward, new DateTime(2019, 09, 14), new DateTime(2019, 09, 15));

			string hotel = hotelSearcher.FindTheCheaperHotel(hotelSearchCriteria);

			Assert.AreEqual("Ridgewood", hotel);
		}

		private HotelSearchCriteria CreateHotelSearchCriteria(CostumerType costumerType, DateTime startDate, DateTime finishDate)
		{
			List<DateTime> dates = new List<DateTime>();

			for (DateTime date = startDate; date <= finishDate; date = date.AddDays(1))
			{
				dates.Add(date);
			}

			return new HotelSearchCriteria(costumerType, dates.ToArray());
		}
	}
}