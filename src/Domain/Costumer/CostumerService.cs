using System;

namespace Domain
{
	public class CostumerService
	{
		public CostumerService(ICostumerRepository costumerRepository)
		{
			CostumerRepository = costumerRepository;
		}

		public ICostumerRepository CostumerRepository { get; }

		public void RegisterCostumer(Costumer costumer)
		{
			CostumerRepository.Save(costumer);
		}
	}
}
