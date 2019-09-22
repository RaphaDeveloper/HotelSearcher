namespace Domain
{
	public class CostumerService
	{
		public ICostumerRepository CostumerRepository { get; }

		public CostumerService(ICostumerRepository costumerRepository)
		{
			CostumerRepository = costumerRepository;
		}

		public void Save(Costumer costumer)
		{

		}
	}
}
