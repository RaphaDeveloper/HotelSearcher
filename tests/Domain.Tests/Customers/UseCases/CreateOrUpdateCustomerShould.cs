using Domain.Customers.Entities;
using Domain.Customers.Repositories;
using Domain.Customers.UseCases;
using Moq;
using NUnit.Framework;

namespace Domain.Tests.Customers.UseCases
{
	public class CreateOrUpdateCustomerShould
	{
		private Mock<ICustomerRepository> costumerRepository;
		private CreateOrUpdateCostumer createOrUpdateCostumer;

		[SetUp]
		public void Setup()
		{
			costumerRepository = new Mock<ICustomerRepository>();

			createOrUpdateCostumer = new CreateOrUpdateCostumer(costumerRepository.Object);
		}

		[Test]
		public void Save_Costumer()
		{
			Customer costumer = CreateCostumer();

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Once);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Name_Is_Null()
		{
			Customer costumer = CreateCostumer();
			costumer.Name = null;

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Name_Is_Empty()
		{
			Customer costumer = CreateCostumer();
			costumer.Name = string.Empty;

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Name_Is_White_Space()
		{
			Customer costumer = CreateCostumer();
			costumer.Name = " ";

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Email_Is_Null()
		{
			Customer costumer = CreateCostumer();
			costumer.Email = null;

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Email_Is_Empty()
		{
			Customer costumer = CreateCostumer();
			costumer.Email = string.Empty;

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_When_Her_Email_Is_White_Space()
		{
			Customer costumer = CreateCostumer();
			costumer.Email = " ";

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Not_Save_Costumer_If_There_Is_Another_Costumer_With_The_Same_Email()
		{
			Customer costumer = CreateCostumer();
			costumerRepository.Setup(c => c.GetByEmail(costumer.Email)).Returns(CreateCostumer);

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Never);
		}

		[Test]
		public void Save_Costumer_If_She_Already_Exists()
		{
			Customer costumer = CreateCostumer();
			costumerRepository.Setup(c => c.GetByEmail(costumer.Email)).Returns(() => costumer);

			createOrUpdateCostumer.Do(costumer);

			costumerRepository.Verify(c => c.Save(costumer), Times.Once);
		}

		private Customer CreateCostumer()
		{
			Customer costumer = new Customer();

			costumer.Name = "Maria";
			costumer.Email = "maria@email.com";

			return costumer;
		}
	}
}
