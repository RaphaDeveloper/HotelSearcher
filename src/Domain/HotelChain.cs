using System.Collections.Generic;

namespace Domain
{
	public class HotelChain
	{
		public List<Hotel> Hotels { get; set; }
		public List<Costumer> Costumers { get; set; }

		public string FindTheCheaperHotel(IHotelSearchCriteria hotelSearchCriteria)
		{
			Hotel cheaperHotel = null;

			foreach (var hotel in Hotels)
			{
				if (cheaperHotel == null || hotel.IsCheaperThan(cheaperHotel, hotelSearchCriteria))
				{
					cheaperHotel = hotel;
				}
			}

			return cheaperHotel.Name;
		}
	}
}
