using Application;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
		public HotelsController(IHotelAppService hotelAppService)
		{
			HotelAppService = hotelAppService;
		}

		private IHotelAppService HotelAppService { get; }

		// GET api/values/5
		[HttpGet("Cheapest/{criteria}")]
		public ActionResult<string> Cheapest(string criteria)
		{
			return HotelAppService.FindTheCheapestHotel(criteria);
		}
	}
}