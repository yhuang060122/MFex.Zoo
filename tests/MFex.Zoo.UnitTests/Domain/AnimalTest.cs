
using FluentAssertions;
using MFex.Zoo.Domain;
using MFex.Zoo.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.UnitTests.Domain
{
    public class AnimalTest
    {
        private readonly Food Meat;
        private readonly Food Fruit;

        public AnimalTest()
        {
            Meat = new Food(FoodTypeEnum.Meat, 12.56m);
            Fruit = new Food(FoodTypeEnum.Fruit, 5.6m);
        }

        [Fact]
        public void Verify_that_CalculSpends_works_Lion_Meat()
        {
            // Arrange
            var lionSam = new Animal(AnimalSpeciesEnum.Lion, "Sam", 160, new List<Zoo.Domain.Records.FoodRate>
            {
                new FoodRate(Meat, 0.1m)
            });

            // Act
            var res = lionSam.CalculSpendsPerDay();

            // Assert
            res.Should().Be(200.96m);
        }

        [Fact]
        public void Verify_that_CalculSpends_works_Giraffe_Fruit()
        {
            // Arrange
            var giraffeAnna = new Animal(AnimalSpeciesEnum.Giraffe, "Anna", 202, new List<Zoo.Domain.Records.FoodRate>
            {
                new FoodRate(Fruit, 0.08m)
            });

            // Act
            var res = giraffeAnna.CalculSpendsPerDay();

            // Assert
            res.Should().Be(90.496m);
        }

        [Fact]
        public void Verify_that_CalculSpends_works_Piranha_Both()
        {
            // Arrange
            var piranha = new Animal(AnimalSpeciesEnum.Piranha, "piranha", 0.5m, new List<Zoo.Domain.Records.FoodRate>
            {
                new FoodRate(Meat, 0.25m),
                new FoodRate(Fruit, 0.3m)
            }); ;

            // Act
            var res = piranha.CalculSpendsPerDay();

            // Assert
            res.Should().Be(2.41m);
        }
    }
}
