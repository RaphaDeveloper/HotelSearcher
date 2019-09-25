﻿using Domain.Hotels.Entities;
using Domain.Hotels.Repositories;
using Domain.Hotels.ValueObjects;

namespace Domain.Hotels.Services
{
	public class HotelService : IHotelService
	{
		public HotelService(IHotelRepository hotelRepository, ICostumerRepository costumerRepository)
		{
			HotelRepository = hotelRepository;
			CostumerRepository = costumerRepository;
		}

		private IHotelRepository HotelRepository { get; }
		private ICostumerRepository CostumerRepository { get; }

		public string FindTheCheapestHotel(IHotelSearchCriteria hotelSearchCriteria)
		{
			Hotel cheapestHotel = null;

			foreach (var hotel in HotelRepository.GetAll())
			{
				if (cheapestHotel == null || hotel.IsCheaperThan(cheapestHotel, hotelSearchCriteria))
				{
					cheapestHotel = hotel;
				}
			}

			return cheapestHotel.Name;
		}

		public void BookHotel(BookingSpecification bookingSpecification)
		{
			Hotel hotel = HotelRepository.GetById(bookingSpecification.HotelId);
			Costumer costumer = CostumerRepository.GetById(bookingSpecification.CostumerId);

			hotel.Book(costumer, bookingSpecification.Dates);
		}
	}
}