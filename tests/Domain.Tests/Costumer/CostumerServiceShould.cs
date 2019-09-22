using Moq;
using NUnit.Framework;

namespace Domain.Tests
{
	public class CostumerServiceShould
	{
		private Mock<ICostumerRepository> costumerRepository;
		private CostumerService costumerService;

		[SetUp]
		public void Setup()
		{
			costumerRepository = new Mock<ICostumerRepository>();

			costumerService = new CostumerService(costumerRepository.Object);
		}

		[Test]
		public void Save_Costumer_When_He_Is_Register()
		{
			Costumer costumer = new Costumer();

			costumerService.RegisterCostumer(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Once);
		}
	}
}
