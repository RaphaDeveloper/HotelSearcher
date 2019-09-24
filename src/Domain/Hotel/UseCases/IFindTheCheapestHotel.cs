namespace Domain
{
	public interface IFindTheCheapestHotel
	{
		string Do(IHotelSearchCriteria hotelSearchCriteria);
	}
}