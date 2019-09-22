namespace Domain
{
	public interface IHotelSearcher
	{
		string FindTheCheaperHotel(IHotelSearchCriteria hotelSearchCriteria);
	}
}