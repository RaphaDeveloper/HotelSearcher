using Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace Application.Tests
{
	public class HotelSearchCriteriaShould
	{
		[Test]
		public void Create_Itself_From_Serialized_Criteria_Of_Regular_Costumer()
		{
			string serializedCriteria = "Regular: 13Sep2019(Fri),14Sep2019(Sat)";

			HotelSearchCriteria hotelSearchCriteria = HotelSearchCriteria.CreateFromSerializedCriteria(serializedCriteria);

			Assert.AreEqual(CostumerType.Regular, hotelSearchCriteria.CostumerType);
			Assert.AreEqual(new DateTime(2019, 09, 13), hotelSearchCriteria.Dates.ElementAt(0));
			Assert.AreEqual(new DateTime(2019, 09, 14), hotelSearchCriteria.Dates.ElementAt(1));
		}

		[Test]
		public void Create_Itself_From_Serialized_Of_Reward_Costumer()
		{
			string serializedCriteria = "Reward: 13Sep2019(Fri),14Sep2019(Sat)";

			HotelSearchCriteria hotelSearchCriteria = HotelSearchCriteria.CreateFromSerializedCriteria(serializedCriteria);

			Assert.AreEqual(CostumerType.Reward, hotelSearchCriteria.CostumerType);
			Assert.AreEqual(new DateTime(2019, 09, 13), hotelSearchCriteria.Dates.ElementAt(0));
			Assert.AreEqual(new DateTime(2019, 09, 14), hotelSearchCriteria.Dates.ElementAt(1));
		}

		[Test]
		public void Implement_The_Domain_Contract()
		{
			Type hotelSearchCriteria = typeof(HotelSearchCriteria);
			Type domainContract = typeof(IHotelSearchCriteria);

			bool implementsDomainContract = domainContract.IsAssignableFrom(hotelSearchCriteria);

			Assert.IsTrue(implementsDomainContract);
		}
	}
}
