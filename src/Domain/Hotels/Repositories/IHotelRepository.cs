using Domain.Hotels.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Hotels.Repositories
{
	public interface IHotelRepository
	{
		IEnumerable<Hotel> GetAll();
		Hotel GetById(Guid id);
	}
}
