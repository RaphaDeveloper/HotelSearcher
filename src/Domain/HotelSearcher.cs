namespace Domain
{
	public class HotelSearcher
	{
		private IHotelRepository HotelRepository { get; }

		public HotelSearcher(IHotelRepository hotelRepository)
		{
			HotelRepository = hotelRepository;
		}

		public string FindTheCheaperHotel(IHotelSearchCriteria hotelSearchCriteria)
		{
			Hotel cheaperHotel = null;

			foreach (var hotel in HotelRepository.GetAll())
			{
				if (cheaperHotel == null)
				{
					cheaperHotel = hotel;

					continue;
				}

				if (hotel.IsCheaperThan(cheaperHotel, hotelSearchCriteria))
				{
					cheaperHotel = hotel;
				}
			}

			return cheaperHotel.Name;
		}
	}
}
