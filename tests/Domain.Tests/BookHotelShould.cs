using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Tests
{
	public class BookHotelShould
	{
		private Mock<IHotelRepository> hotelRepository;
		private Mock<ICostumerRepository> costumerRepository;

		private BookHotel bookHotel;

		[SetUp]
		public void Setup()
		{
			hotelRepository = new Mock<IHotelRepository>();
			costumerRepository = new Mock<ICostumerRepository>();

			bookHotel = new BookHotel(hotelRepository.Object, costumerRepository.Object);
		}

		[Test]
		public void Add_Booking_On_Hotel()
		{
			BookingSpecification bookingSpecification = new BookingSpecification(Guid.NewGuid(), Guid.NewGuid(), new DateTime[] { new DateTime(2019, 09, 22) });

			Hotel hotel = new Hotel { Id = bookingSpecification.HotelId };
			Costumer costumer = new Costumer { Id = bookingSpecification.CostumerId };

			hotelRepository.Setup(h => h.GetById(bookingSpecification.HotelId)).Returns(hotel);
			costumerRepository.Setup(h => h.GetById(bookingSpecification.CostumerId)).Returns(costumer);


			bookHotel.Do(bookingSpecification);


			Assert.AreEqual(1, hotel.Bookings.Count);
			Assert.AreEqual(costumer, hotel.Bookings.Single().Costumer);
			Assert.AreEqual(hotel, hotel.Bookings.Single().Hotel);
			Assert.AreEqual(bookingSpecification.Dates, hotel.Bookings.Single().Dates);
		}

		[Test]
		public void Add_Booking_On_Costumer()
		{
			BookingSpecification bookingSpecification = new BookingSpecification(Guid.NewGuid(), Guid.NewGuid(), new DateTime[] { new DateTime(2019, 09, 22) });

			Hotel hotel = new Hotel { Id = bookingSpecification.HotelId };
			Costumer costumer = new Costumer { Id = bookingSpecification.CostumerId };

			hotelRepository.Setup(h => h.GetById(bookingSpecification.HotelId)).Returns(hotel);
			costumerRepository.Setup(h => h.GetById(bookingSpecification.CostumerId)).Returns(costumer);


			bookHotel.Do(bookingSpecification);


			Assert.AreEqual(1, costumer.Bookings.Count);
			Assert.AreEqual(hotel, costumer.Bookings.Single().Hotel);
			Assert.AreEqual(costumer, costumer.Bookings.Single().Costumer);
			Assert.AreEqual(bookingSpecification.Dates, costumer.Bookings.Single().Dates);
		}

		[Test]
		public void Not_Book_Hotel_When_There_Is_Another_Book_In_The_Same_Period_For_The_Same_Costumer()
		{
			IEnumerable<DateTime> dates = new DateTime[] { new DateTime(2019, 09, 22) };
			BookingSpecification bookingSpecification = new BookingSpecification(Guid.NewGuid(), Guid.NewGuid(), dates);

			Costumer costumer = new Costumer { Id = bookingSpecification.CostumerId };
			Hotel hotel = new Hotel { Id = bookingSpecification.HotelId };
			Booking booking = new Booking(hotel, costumer, dates);
			hotel.Bookings = new List<Booking> { booking };
			costumer.Bookings = new List<Booking> { booking };

			hotelRepository.Setup(h => h.GetById(bookingSpecification.HotelId)).Returns(hotel);
			costumerRepository.Setup(h => h.GetById(bookingSpecification.CostumerId)).Returns(costumer);


			bookHotel.Do(bookingSpecification);


			Assert.AreEqual(1, hotel.Bookings.Count);
		}
	}
}
