using Domain.Customers.Entities;
using Domain.Customers.Repositories;
using Domain.Hotels.Entities;
using Domain.Hotels.Repositories;
using Domain.Hotels.ValueObjects;

namespace Domain
{
	public class BookHotel
	{
		public BookHotel(IHotelRepository hotelRepository, ICustomerRepository costumerRepository)
		{
			HotelRepository = hotelRepository;
			CostumerRepository = costumerRepository;
		}

		public IHotelRepository HotelRepository { get; }
		public ICustomerRepository CostumerRepository { get; }

		public void Do(BookingSpecification bookingSpecification)
		{
			Hotel hotel = HotelRepository.GetById(bookingSpecification.HotelId);
			Customer costumer = CostumerRepository.GetById(bookingSpecification.CostumerId);
			
			hotel.Book(costumer, bookingSpecification.Dates);
		}
	}
}
