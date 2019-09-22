using NUnit.Framework;
using System;

namespace Domain.Tests
{
	class CostumerShould
	{
		[Test]
		public void Create_Id_On_Instantiation()
		{
			Costumer costumer = new Costumer();

			Assert.AreNotEqual(Guid.Empty, costumer.Id);
		}
	}
}
