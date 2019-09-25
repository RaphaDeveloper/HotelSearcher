using Application.Services;
using Domain;
using Domain.Customers.ValueObjects;
using Domain.Hotels.Services;
using Domain.Hotels.ValueObjects;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace Application.Tests.Hotels.Services
{
	public class HotelAppServiceShould
	{
		private Mock<IHotelService> hotelService;

		private HotelAppService hotelAppService;

		[SetUp]
		public void Setup()
		{
			hotelService = new Mock<IHotelService>();

			hotelAppService = new HotelAppService(hotelService.Object);
		}

		[Test]
		public void Find_The_Cheapest_Hotel()
		{
			string criteria = "Regular: 13Sep2019(Fri),14Sep2019(Sat)";
			hotelService
				.Setup(f => 
					f.FindTheCheapestHotel(It.Is<IHotelSearchCriteria>(c => 
						c.CostumerType == CostumerType.Regular && 
						c.Dates.Contains(new DateTime(2019, 09, 13)) &&
						c.Dates.Contains(new DateTime(2019, 09, 14)))))
				.Returns("Lakewood");


			string hotel = hotelAppService.FindTheCheapestHotel(criteria);

			
			Assert.AreEqual("Lakewood", hotel);
		}
	}
}
