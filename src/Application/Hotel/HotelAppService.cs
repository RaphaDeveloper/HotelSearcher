using Domain;

namespace Application
{
	public class HotelAppService : IHotelAppService
	{
		private IFindTheCheapestHotel findTheCheapestHotel;

		public HotelAppService(IFindTheCheapestHotel findTheCheapestHotel)
		{
			this.findTheCheapestHotel = findTheCheapestHotel;
		}

		public string FindTheCheapestHotel(string criteria)
		{
			return findTheCheapestHotel.Do(HotelSearchCriteria.CreateFromSerializedCriteria(criteria));
		}
	}
}
