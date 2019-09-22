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
			if (costumer.IsValid && !ThereIsAnotherCostumerWithTheEmail(costumer.Email))
			{
				CostumerRepository.Save(costumer);
			}
		}

		private bool ThereIsAnotherCostumerWithTheEmail(string email)
		{
			return CostumerRepository.GetByEmail(email) != null;
		}
	}
}
