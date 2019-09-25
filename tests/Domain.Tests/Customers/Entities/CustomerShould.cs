using Domain.Customers.Entities;
using NUnit.Framework;
using System;

namespace Domain.Tests.Costumers.Entities
{
	class CustomerShould
	{
		[Test]
		public void Create_Id_On_Instantiation()
		{
			Customer costumer = new Customer();

			Assert.AreNotEqual(Guid.Empty, costumer.Id);
		}
	}
}
