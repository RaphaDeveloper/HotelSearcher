using System;
using System.Collections.Generic;

namespace Domain.Tests.Stubs
{
	public class HotelSearchCriteria : IHotelSearchCriteria
	{
		public HotelSearchCriteria(CostumerType costumerType, params DateTime[] dates)
		{
			CostumerType = costumerType;
			Dates = dates;
		}

		public CostumerType CostumerType { get; }

		public IEnumerable<DateTime> Dates { get; }
	}
}
