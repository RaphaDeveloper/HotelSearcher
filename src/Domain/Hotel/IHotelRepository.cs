using System;
using System.Collections.Generic;

namespace Domain
{
	public interface IHotelRepository
	{
		IEnumerable<Hotel> GetAll();
		Hotel GetById(Guid id);
	}
}
