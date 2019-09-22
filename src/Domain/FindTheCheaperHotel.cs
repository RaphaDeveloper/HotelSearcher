namespace Domain
{
	public class FindTheCheaperHotel
	{
		public IHotelSearcher HotelSearcher { get; }

		public FindTheCheaperHotel(IHotelSearcher hotelSearcher)
		{
			HotelSearcher = hotelSearcher;
		}

		public string Do(IHotelSearchCriteria hotelSearchCriteria)
		{
			return HotelSearcher.FindTheCheaperHotel(hotelSearchCriteria);
		}
	}
}
