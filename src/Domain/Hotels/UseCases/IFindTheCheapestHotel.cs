using Domain.Hotels.ValueObjects;

namespace Domain.Hotels.UseCases
{
	public interface IFindTheCheapestHotel
	{
		string Do(IHotelSearchCriteria hotelSearchCriteria);
	}
}