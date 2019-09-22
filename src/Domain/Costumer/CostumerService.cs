namespace Domain
{
	public class CostumerService
	{
		public CostumerService(ICostumerRepository costumerRepository)
		{
			CostumerRepository = costumerRepository;
		}

		public ICostumerRepository CostumerRepository { get; }

		public void Save(Costumer costumer)
		{
			if (costumer.IsValid && !ThereIsAnotherCostumerWithTheEmail(costumer))
			{
				CostumerRepository.Save(costumer);
			}
		}

		private bool ThereIsAnotherCostumerWithTheEmail(Costumer costumer)
		{
			Costumer anotherCostumer = CostumerRepository.GetByEmail(costumer.Email);

			return anotherCostumer != null && anotherCostumer.Id != costumer.Id;
		}
	}
}
