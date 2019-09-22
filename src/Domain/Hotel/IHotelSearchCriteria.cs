using System;
using System.Collections.Generic;

namespace Domain
{
	public interface IHotelSearchCriteria
	{
		CostumerType CostumerType { get; }
		IEnumerable<DateTime> Dates { get; }
	}
}
