using API.Controllers;
using Application.Services;
using Moq;
using NUnit.Framework;

namespace Tests
{
	public class HotelsControllerShould
	{
		private Mock<IHotelAppService> hotelAppService;

		private HotelsController hotelsController;

		[SetUp]
		public void Setup()
		{
			hotelAppService = new Mock<IHotelAppService>();

			hotelsController = new HotelsController(hotelAppService.Object);
		}

		[Test]
		public void Return_The_Cheapest_Hotel()
		{
			string criteria = "Regular: 13Sep2019(Fri),14Sep2019(Sat)";
			hotelAppService.Setup(h => h.FindTheCheapestHotel(criteria)).Returns("Lakewood");

			var result = hotelsController.Cheapest(criteria);

			Assert.AreEqual(result.Value, "Lakewood");
		}
	}
}