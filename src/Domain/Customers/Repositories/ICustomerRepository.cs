using Domain.Customers.Entities;
using System;

namespace Domain.Customers.Repositories
{
	public interface ICustomerRepository
	{
		void Save(Customer costumer);
		Customer GetByEmail(string email);
		Customer GetById(Guid id);
	}
}
