using Application.Models;
using Domain.Hotels.Services;

namespace Application.Services
{
	public class HotelAppService : IHotelAppService
	{
		public HotelAppService(IHotelService hotelService)
		{
			HotelService = hotelService;
		}

		private IHotelService HotelService { get; }

		public string FindTheCheapestHotel(string criteria)
		{
			return HotelService.FindTheCheapestHotel(HotelSearchCriteria.CreateFromSerializedCriteria(criteria));
		}
	}
}
