using FluentAssertions;
using MFex.Zoo.Application.Interfaces;
using MFex.Zoo.Application.UseCases;
using MFex.Zoo.Domain;
using MFex.Zoo.Domain.IRepository;
using MFex.Zoo.Domain.Records;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.UnitTests.Application
{
    public class ZooUseCaseTest
    {
        private readonly Food Meat;
        private readonly Food Fruit;

        public ZooUseCaseTest()
        {
            Meat = new Food(FoodTypeEnum.Meat, 12.56m);
            Fruit = new Food(FoodTypeEnum.Fruit, 5.6m);
        }

        [Fact]
        public void ShouldCalculSpends()
        {
            // Arrange
            var mockZooRepo = new Mock<IZooRepository>();
            mockZooRepo.Setup(m => m.GetPrices()).Returns(new List<Food> {Meat, Fruit});
            mockZooRepo.Setup(m => m.GetFoodRates()).Returns(new List<AnimalFoodRate> {
                new AnimalFoodRate(AnimalSpeciesEnum.Lion, FoodTypeEnum.Meat, 0.1m),
                new AnimalFoodRate(AnimalSpeciesEnum.Giraffe, FoodTypeEnum.Fruit, 0.08m),
                new AnimalFoodRate(AnimalSpeciesEnum.Piranha, FoodTypeEnum.Meat, 0.25m),
                new AnimalFoodRate(AnimalSpeciesEnum.Piranha, FoodTypeEnum.Fruit, 0.3m)
            });
            mockZooRepo.Setup(m => m.GetAnimalWeights()).Returns(new List<AnimalWeight> {
                new AnimalWeight(AnimalSpeciesEnum.Lion, "Sam", 160),
                new AnimalWeight(AnimalSpeciesEnum.Giraffe, "Anna", 202),
                new AnimalWeight(AnimalSpeciesEnum.Piranha, "piranha", 0.5m)
            });
            IZooUseCase zooUseCase = new ZooUseCase(mockZooRepo.Object);

            // Act
            var res = zooUseCase.CalculSpends();

            // Assert
            res.Should().Be(293.866m);
        }
    }
}
