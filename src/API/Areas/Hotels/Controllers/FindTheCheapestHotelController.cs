using Application.Hotels.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.Hotels.Controllers
{
	[Route("api/hotels/[controller]")]
    [ApiController]
    public class FindTheCheapestHotelController : ControllerBase
    {
		public FindTheCheapestHotelController(IFindTheCheapestHotelApp findTheCheapestHotelApp)
		{
			FindTheCheapestHotelApp = findTheCheapestHotelApp;
		}

		public IFindTheCheapestHotelApp FindTheCheapestHotelApp { get; }

		[HttpGet("{criteria}")]
		public ActionResult<string> Get(string criteria)
		{
			return FindTheCheapestHotelApp.Do(criteria);
		}
	}
}