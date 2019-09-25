using Domain.Customers.Entities;
using Domain.Customers.Repositories;
using Domain.Customers.ValueObjects;
using Domain.Hotels.Entities;
using Domain.Hotels.Repositories;
using Domain.Hotels.UseCases;
using Domain.Hotels.ValueObjects;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Tests.Hotels.UseCases
{
	public class BookHotelShould
	{
		private Mock<IHotelRepository> hotelRepository;
		private Mock<ICustomerRepository> costumerRepository;

		private BookHotel bookHotel;

		[SetUp]
		public void Setup()
		{
			hotelRepository = new Mock<IHotelRepository>();
			costumerRepository = new Mock<ICustomerRepository>();

			bookHotel = new BookHotel(hotelRepository.Object, costumerRepository.Object);
		}

		[Test]
		public void Add_Booking_To_Hotel()
		{
			BookingSpecification bookingSpecification = new BookingSpecification(Guid.NewGuid(), Guid.NewGuid(), new DateTime[] { new DateTime(2019, 09, 22) });

			Hotel hotel = CreateHotel(bookingSpecification.HotelId);
			Customer costumer = new Customer { Id = bookingSpecification.CostumerId };

			hotelRepository.Setup(h => h.GetById(bookingSpecification.HotelId)).Returns(hotel);
			costumerRepository.Setup(h => h.GetById(bookingSpecification.CostumerId)).Returns(costumer);


			bookHotel.Do(bookingSpecification);


			Assert.AreEqual(1, hotel.Bookings.Count);
			Assert.AreEqual(costumer, hotel.Bookings.Single().Customer);
			Assert.AreEqual(hotel, hotel.Bookings.Single().Hotel);
			Assert.AreEqual(bookingSpecification.Dates, hotel.Bookings.Single().Dates);
		}

		[Test]
		public void Add_Booking_To_Costumer()
		{
			BookingSpecification bookingSpecification = new BookingSpecification(Guid.NewGuid(), Guid.NewGuid(), new DateTime[] { new DateTime(2019, 09, 22) });

			Hotel hotel = CreateHotel(bookingSpecification.HotelId);
			Customer costumer = new Customer { Id = bookingSpecification.CostumerId };

			hotelRepository.Setup(h => h.GetById(bookingSpecification.HotelId)).Returns(hotel);
			costumerRepository.Setup(h => h.GetById(bookingSpecification.CostumerId)).Returns(costumer);


			bookHotel.Do(bookingSpecification);


			Assert.AreEqual(1, costumer.Bookings.Count);
			Assert.AreEqual(hotel, costumer.Bookings.Single().Hotel);
			Assert.AreEqual(costumer, costumer.Bookings.Single().Customer);
			Assert.AreEqual(bookingSpecification.Dates, costumer.Bookings.Single().Dates);
		}

		[Test]
		public void Calculate_Total_Price_For_The_Booking()
		{
			IEnumerable<DateTime> dates = new DateTime[] { new DateTime(2019, 09, 21), new DateTime(2019, 09, 22), new DateTime(2019, 09, 23) };

			BookingSpecification bookingSpecification = new BookingSpecification(Guid.NewGuid(), Guid.NewGuid(), dates);

			Hotel hotel = CreateHotel(bookingSpecification.HotelId);
			Customer costumer = new Customer { Id = bookingSpecification.CostumerId };

			hotelRepository.Setup(h => h.GetById(bookingSpecification.HotelId)).Returns(hotel);
			costumerRepository.Setup(h => h.GetById(bookingSpecification.CostumerId)).Returns(costumer);


			bookHotel.Do(bookingSpecification);


			Assert.AreEqual(200, hotel.Bookings.Single().TotalPrice);
		}

		[Test]
		public void Not_Book_Hotel_When_There_Is_Another_Book_In_The_Same_Period_For_The_Same_Costumer()
		{
			IEnumerable<DateTime> dates = new DateTime[] { new DateTime(2019, 09, 22) };
			BookingSpecification bookingSpecification = new BookingSpecification(Guid.NewGuid(), Guid.NewGuid(), dates);

			Customer costumer = new Customer { Id = bookingSpecification.CostumerId };
			Hotel hotel = CreateHotel(bookingSpecification.HotelId);
			Booking booking = new Booking(hotel, costumer, dates, 50);
			hotel.Bookings = new List<Booking> { booking };
			costumer.Bookings = new List<Booking> { booking };

			hotelRepository.Setup(h => h.GetById(bookingSpecification.HotelId)).Returns(hotel);
			costumerRepository.Setup(h => h.GetById(bookingSpecification.CostumerId)).Returns(costumer);


			bookHotel.Do(bookingSpecification);


			Assert.AreEqual(1, hotel.Bookings.Count);
		}

		private Hotel CreateHotel(Guid hotelId)
		{
			return new Hotel
			{
				Id = hotelId,
				PriceByCostumerType = new Dictionary<CostumerType, Price>
				{
					{ CostumerType.Regular, new Price(100, 50) },
					{ CostumerType.Reward, new Price(80, 40) }
				}
			};
		}
	}
}
