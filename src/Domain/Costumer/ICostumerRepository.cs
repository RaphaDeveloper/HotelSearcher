namespace Domain
{
	public interface ICostumerRepository
	{
		void Save(Costumer costumer);
		Costumer GetByEmail(string email);
	}
}
