using System.Collections.Generic;

namespace Domain
{
	public interface IHotelRepository
	{
		IEnumerable<Hotel> GetAll();
	}
}
