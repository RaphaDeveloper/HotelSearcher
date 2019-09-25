using Domain.Hotels.Entities;
using Domain.Hotels.Repositories;
using Domain.Hotels.ValueObjects;

namespace Domain
{
	public class FindTheCheapestHotel : IFindTheCheapestHotel
	{
		private IHotelRepository HotelRepository { get; }

		public FindTheCheapestHotel(IHotelRepository hotelRepository)
		{
			HotelRepository = hotelRepository;
		}

		public string Do(IHotelSearchCriteria hotelSearchCriteria)
		{
			Hotel cheapestHotel = null;

			foreach (var hotel in HotelRepository.GetAll())
			{
				if (cheapestHotel == null || hotel.IsCheaperThan(cheapestHotel, hotelSearchCriteria))
				{
					cheapestHotel = hotel;
				}
			}

			return cheapestHotel.Name;
		}
	}
}
