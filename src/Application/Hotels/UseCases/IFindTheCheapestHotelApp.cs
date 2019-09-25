namespace Application.Hotels.UseCases
{
	public interface IFindTheCheapestHotelApp
	{
		string Do(string serializedCriteria);
	}
}