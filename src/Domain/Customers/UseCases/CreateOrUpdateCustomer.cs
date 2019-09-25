using Domain.Customers.Entities;
using Domain.Customers.Repositories;

namespace Domain.Customers.UseCases
{
	public class CreateOrUpdateCostumer
	{
		public CreateOrUpdateCostumer(ICustomerRepository costumerRepository)
		{
			CostumerRepository = costumerRepository;
		}

		public ICustomerRepository CostumerRepository { get; }

		public void Do(Customer costumer)
		{
			if (costumer.IsValid && !ThereIsAnotherCostumerWithTheEmail(costumer))
			{
				CostumerRepository.Save(costumer);
			}
		}

		private bool ThereIsAnotherCostumerWithTheEmail(Customer costumer)
		{
			Customer anotherCostumer = CostumerRepository.GetByEmail(costumer.Email);

			return anotherCostumer != null && anotherCostumer.Id != costumer.Id;
		}
	}
}
