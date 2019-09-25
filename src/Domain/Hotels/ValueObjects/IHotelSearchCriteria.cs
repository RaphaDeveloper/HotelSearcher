using System;
using System.Collections.Generic;

namespace Domain.Hotels.ValueObjects
{
	public interface IHotelSearchCriteria
	{
		CostumerType CostumerType { get; }
		IEnumerable<DateTime> Dates { get; }
	}
}
