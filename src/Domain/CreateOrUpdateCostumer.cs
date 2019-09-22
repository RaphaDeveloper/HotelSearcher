namespace Domain
{
	public class CreateOrUpdateCostumer
	{
		public CreateOrUpdateCostumer(ICostumerRepository costumerRepository)
		{
			CostumerRepository = costumerRepository;
		}

		public ICostumerRepository CostumerRepository { get; }

		public void Do(Costumer costumer)
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
