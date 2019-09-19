using System.Collections.Generic;

namespace Domain
{
	public class HotelRepository : IHotelRepository
	{
		public IEnumerable<Hotel> GetAll()
		{
			Hotel lakewood = new Hotel
			{
				Name = "Lakewood",
				RateByCostumerType = new Dictionary<CostumerType, Rate>
				{
					{ CostumerType.Regular, new Rate(110, 90) },
					{ CostumerType.Reward, new Rate(80, 80) }
				}
			};

			Hotel bridgewood = new Hotel
			{
				Name = "Bridgewood",
				RateByCostumerType = new Dictionary<CostumerType, Rate>
				{
					{ CostumerType.Regular, new Rate(160, 60) },
					{ CostumerType.Reward, new Rate(110, 50) }
				}
			};

			Hotel ridgewood = new Hotel
			{
				Name = "Ridgewood",
				RateByCostumerType = new Dictionary<CostumerType, Rate>
				{
					{ CostumerType.Regular, new Rate(220, 150) },
					{ CostumerType.Reward, new Rate(100, 40) }
				}
			};

			yield return lakewood;
			yield return bridgewood;
			yield return ridgewood;
		}
	}
}
