using Moq;
using NUnit.Framework;

namespace Domain.Tests.Costumer
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
		public void Save_Costumer()
		{
			costumerRepository.Verify(c => c.Save(costumer), Times.Once);
		}
	}
}
