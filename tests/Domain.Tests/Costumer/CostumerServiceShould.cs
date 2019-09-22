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
		public void Save_Costumer()
		{
			Costumer costumer = CreateCostumer();

			costumerService.Save(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Once);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Name_Is_Null()
		{
			Costumer costumer = CreateCostumer();
			costumer.Name = null;

			costumerService.Save(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Name_Is_Empty()
		{
			Costumer costumer = CreateCostumer();
			costumer.Name = string.Empty;

			costumerService.Save(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Name_Is_White_Space()
		{
			Costumer costumer = CreateCostumer();
			costumer.Name = " ";

			costumerService.Save(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Email_Is_Null()
		{
			Costumer costumer = CreateCostumer();
			costumer.Email = null;

			costumerService.Save(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Email_Is_Empty()
		{
			Costumer costumer = CreateCostumer();
			costumer.Email = string.Empty;

			costumerService.Save(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Email_Is_White_Space()
		{
			Costumer costumer = CreateCostumer();
			costumer.Email = " ";

			costumerService.Save(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_If_There_Is_Another_Costumer_With_The_Same_Email()
		{
			Costumer costumer = CreateCostumer();
			costumerRepository.Setup(c => c.GetByEmail(costumer.Email)).Returns(CreateCostumer);

			costumerService.Save(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		private Costumer CreateCostumer()
		{
			Costumer costumer = new Costumer();

			costumer.Name = "Maria";
			costumer.Email = "maria@email.com";

			return costumer;
		}
	}
}
