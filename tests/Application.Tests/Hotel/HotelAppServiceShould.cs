using Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Tests.Hotel
{
	public class HotelAppServiceShould
	{
		private Mock<IFindTheCheapestHotel> findTheCheapestHotel;

		private HotelAppService hotelAppService;

		[SetUp]
		public void Setup()
		{
			findTheCheapestHotel = new Mock<IFindTheCheapestHotel>();

			hotelAppService = new HotelAppService(findTheCheapestHotel.Object);
		}

		[Test]
		public void Find_The_Cheapest_Hotel()
		{
			string criteria = "Regular: 13Sep2019(Fri),14Sep2019(Sat)";
			findTheCheapestHotel
				.Setup(f => 
					f.Do(It.Is<IHotelSearchCriteria>(c => 
						c.CostumerType == CostumerType.Regular && 
						c.Dates.Contains(new DateTime(2019, 09, 13)) &&
						c.Dates.Contains(new DateTime(2019, 09, 14)))))
				.Returns("Lakewood");


			string hotel = hotelAppService.FindTheCheapestHotel(criteria);

			
			Assert.AreEqual("Lakewood", hotel);
		}
	}
}
