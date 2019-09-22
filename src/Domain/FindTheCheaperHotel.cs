namespace Domain
{
	public class FindTheCheaperHotel
	{
		public IHotelChainRepository HotelChainRepository { get; }

		public FindTheCheaperHotel(IHotelChainRepository hotelChainRepository)
		{
			HotelChainRepository = hotelChainRepository;
		}

		public string Do(IHotelSearchCriteria hotelSearchCriteria)
		{
			HotelChain hotelChain = HotelChainRepository.GetFirst();

			return hotelChain.FindTheCheaperHotel(hotelSearchCriteria);
		}
	}
}
