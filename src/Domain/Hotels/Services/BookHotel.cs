using Domain.Hotels.Entities;
using Domain.Hotels.Repositories;
using Domain.Hotels.ValueObjects;

namespace Domain
{
	public class BookHotel
	{
		public BookHotel(IHotelRepository hotelRepository, ICostumerRepository costumerRepository)
		{
			HotelRepository = hotelRepository;
			CostumerRepository = costumerRepository;
		}

		public IHotelRepository HotelRepository { get; }
		public ICostumerRepository CostumerRepository { get; }

		public void Do(BookingSpecification bookingSpecification)
		{
			Hotel hotel = HotelRepository.GetById(bookingSpecification.HotelId);
			Costumer costumer = CostumerRepository.GetById(bookingSpecification.CostumerId);
			
			hotel.Book(costumer, bookingSpecification.Dates);
		}
	}
}
