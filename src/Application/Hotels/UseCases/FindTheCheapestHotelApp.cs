using Application.Models;
using Domain.Hotels.UseCases;
using Domain.Hotels.ValueObjects;

namespace Application.Hotels.UseCases
{
	public class FindTheCheapestHotelApp : IFindTheCheapestHotelApp
	{
		public FindTheCheapestHotelApp(IFindTheCheapestHotel findTheCheapestHotel)
		{
			FindTheCheapestHotel = findTheCheapestHotel;
		}

		public IFindTheCheapestHotel FindTheCheapestHotel { get; }

		public string Do(string serializedCriteria)
		{
			IHotelSearchCriteria hotelSearchCriteria = HotelSearchCriteria.CreateFromSerializedCriteria(serializedCriteria);

			return FindTheCheapestHotel.Do(hotelSearchCriteria);
		}
	}
}
