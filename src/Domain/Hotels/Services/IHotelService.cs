using Domain.Hotels.ValueObjects;

namespace Domain.Hotels.Services
{
	public interface IHotelService
	{
		void BookHotel(BookingSpecification bookingSpecification);
		string FindTheCheapestHotel(IHotelSearchCriteria hotelSearchCriteria);
	}
}