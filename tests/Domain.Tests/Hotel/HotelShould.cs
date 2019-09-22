using Domain.Tests.Stubs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tests
{
	public class HotelShould
	{
		private Hotel lakewood;
		private Hotel bridgewood;
		private Hotel ridgewood;
		private Hotel seawood;

		[SetUp]
		public void Setup()
		{
			lakewood = new Hotel
			{
				Name = "Lakewood",
				Rating = 3,
				PriceByCostumerType = new Dictionary<CostumerType, Price>
				{
					{ CostumerType.Regular, new Price(110, 90) },
					{ CostumerType.Reward, new Price(80, 80) }
				}
			};

			bridgewood = new Hotel
			{
				Name = "Bridgewood",
				Rating = 4,
				PriceByCostumerType = new Dictionary<CostumerType, Price>
				{
					{ CostumerType.Regular, new Price(160, 60) },
					{ CostumerType.Reward, new Price(110, 50) }
				}
			};

			ridgewood = new Hotel
			{
				Name = "Ridgewood",
				Rating = 5,
				PriceByCostumerType = new Dictionary<CostumerType, Price>
				{
					{ CostumerType.Regular, new Price(220, 150) },
					{ CostumerType.Reward, new Price(100, 40) }
				}
			};

			seawood = new Hotel
			{
				Name = "Seawood",
				Rating = 4,
				PriceByCostumerType = new Dictionary<CostumerType, Price>
				{
					{ CostumerType.Regular, new Price(220, 150) },
					{ CostumerType.Reward, new Price(100, 40) }
				}
			};
		}

		[Test]
		public void Compare_If_Is_Cheaper_Than_Another_Hotel_In_Week_Day_For_Regular_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Regular, new DateTime(2019, 09, 09), new DateTime(2019, 09, 13));

			bool lakewoodIsCheaperThanBridgewood = lakewood.IsCheaperThan(bridgewood, hotelSearchCriteria);

			Assert.IsTrue(lakewoodIsCheaperThanBridgewood);
		}

		[Test]
		public void Compare_If_Is_Cheaper_Than_Another_Hotel_In_Weekend_Day_For_Regular_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Regular, new DateTime(2019, 09, 14), new DateTime(2019, 09, 15));

			bool bridgewoodIsCheaperThanLakewood = bridgewood.IsCheaperThan(lakewood, hotelSearchCriteria);

			Assert.IsTrue(bridgewoodIsCheaperThanLakewood);
		}

		[Test]
		public void Compare_If_Is_Cheaper_Than_Another_Hotel_In_Week_Day_For_Reward_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Reward, new DateTime(2019, 09, 09), new DateTime(2019, 09, 13));

			bool lakewoodIsCheaperThanRidgewood = lakewood.IsCheaperThan(ridgewood, hotelSearchCriteria);

			Assert.IsTrue(lakewoodIsCheaperThanRidgewood);
		}

		[Test]
		public void Compare_If_Is_Cheaper_Than_Another_Hotel_In_Weekend_Day_For_Reward_Costumer()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Reward, new DateTime(2019, 09, 14), new DateTime(2019, 09, 15));

			bool ridgewoodIsCheaperThanLakewood = ridgewood.IsCheaperThan(lakewood, hotelSearchCriteria);

			Assert.IsTrue(ridgewoodIsCheaperThanLakewood);
		}

		[Test]
		public void Compare_If_Is_Cheaper_Than_Another_Hotel_Considering_The_Hotel_Rating_When_There_Is_A_Tie_On_Rate()
		{
			HotelSearchCriteria hotelSearchCriteria = CreateHotelSearchCriteria(CostumerType.Reward, new DateTime(2019, 09, 14), new DateTime(2019, 09, 15));

			bool ridgewoodIsCheaperThanSeawood = ridgewood.IsCheaperThan(seawood, hotelSearchCriteria);

			Assert.IsTrue(ridgewoodIsCheaperThanSeawood);
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
