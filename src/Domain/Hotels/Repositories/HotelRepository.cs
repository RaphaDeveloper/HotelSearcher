using Domain.Customers.ValueObjects;
using Domain.Hotels.Entities;
using Domain.Hotels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Hotels.Repositories
{
	public class HotelRepository : IHotelRepository
	{
		public IEnumerable<Hotel> GetAll()
		{
			Hotel lakewood = new Hotel
			{
				Name = "Lakewood",
				PriceByCostumerType = new Dictionary<CostumerType, Price>
				{
					{ CostumerType.Regular, new Price(110, 90) },
					{ CostumerType.Reward, new Price(80, 80) }
				}
			};

			Hotel bridgewood = new Hotel
			{
				Name = "Bridgewood",
				PriceByCostumerType = new Dictionary<CostumerType, Price>
				{
					{ CostumerType.Regular, new Price(160, 60) },
					{ CostumerType.Reward, new Price(110, 50) }
				}
			};

			Hotel ridgewood = new Hotel
			{
				Name = "Ridgewood",
				PriceByCostumerType = new Dictionary<CostumerType, Price>
				{
					{ CostumerType.Regular, new Price(220, 150) },
					{ CostumerType.Reward, new Price(100, 40) }
				}
			};

			yield return lakewood;
			yield return bridgewood;
			yield return ridgewood;
		}

		public Hotel GetById(Guid id)
		{
			return GetAll().SingleOrDefault(h => h.Id == id);
		}
	}
}
