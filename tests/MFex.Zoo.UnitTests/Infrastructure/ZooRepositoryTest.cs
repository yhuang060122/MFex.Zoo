using FluentAssertions;
using MFex.Zoo.Domain;
using MFex.Zoo.Domain.IRepository;
using MFex.Zoo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.UnitTests.Infrastructure
{
    public class ZooRepositoryTest
    {
        private readonly IZooRepository _repo;

        public ZooRepositoryTest()
        {
            // Arrange
            string rootPath = Path.Combine(Path.GetDirectoryName(typeof(ZooRepositoryTest).Assembly.Location), "sources");
            _repo = new ZooRepository(rootPath);
        }

        [Fact]
        public void Verify_that_GetPrices_works()
        {
            // Act
            var res = _repo.GetPrices();

            // Assert
            res.Should().SatisfyRespectively(
                first =>
                {
                    first.FoodType.Should().Be(FoodTypeEnum.Meat);
                    first.Price.Should().Be(12.56m);
                },
                second =>
                {
                    second.FoodType.Should().Be(FoodTypeEnum.Fruit);
                    second.Price.Should().Be(5.6m);
                });
        }

        [Fact]
        public void Verify_that_GetFoodRates_works()
        {
            // Act
            var res = _repo.GetFoodRates();

            // Assert
            res.Should().SatisfyRespectively(
            el1 =>
            {
                el1.Species.Should().Be(AnimalSpeciesEnum.Lion);
                el1.FoodType.Should().Be(FoodTypeEnum.Meat);
                el1.Rate.Should().Be(0.1m);
            },
            el2 =>
            {
                el2.Species.Should().Be(AnimalSpeciesEnum.Tiger);
                el2.FoodType.Should().Be(FoodTypeEnum.Meat);
                el2.Rate.Should().Be(0.09m);
            },
            el3 =>
            {
                el3.Species.Should().Be(AnimalSpeciesEnum.Giraffe);
                el3.FoodType.Should().Be(FoodTypeEnum.Fruit);
                el3.Rate.Should().Be(0.08m);
            },
            el4 =>
            {
                el4.Species.Should().Be(AnimalSpeciesEnum.Zebra);
                el4.FoodType.Should().Be(FoodTypeEnum.Fruit);
                el4.Rate.Should().Be(0.08m);
            },
            el5 =>
            {
                el5.Species.Should().Be(AnimalSpeciesEnum.Wolf);
                el5.FoodType.Should().Be(FoodTypeEnum.Meat);
                el5.Rate.Should().Be(0.063m);
            },
            el6 =>
            {
                el6.Species.Should().Be(AnimalSpeciesEnum.Wolf);
                el6.FoodType.Should().Be(FoodTypeEnum.Fruit);
                el6.Rate.Should().Be(0.007m);
            },
            el7 =>
            {
                el7.Species.Should().Be(AnimalSpeciesEnum.Piranha);
                el7.FoodType.Should().Be(FoodTypeEnum.Meat);
                el7.Rate.Should().Be(0.25m);
            },
            el8 =>
            {
                el8.Species.Should().Be(AnimalSpeciesEnum.Piranha);
                el8.FoodType.Should().Be(FoodTypeEnum.Fruit);
                el8.Rate.Should().Be(0.25m);
            }
                );

        }

        [Fact]
        public void Verify_that_GetAnimalWeights_works()
        {
            // Act
            var res = _repo.GetAnimalWeights();

            // Assert
            res.Should().SatisfyRespectively(
                el1 =>
                {
                    el1.Species.Should().Be(AnimalSpeciesEnum.Lion);
                    el1.Name.Should().Be("Simba");
                    el1.Weight.Should().Be(160);
                }, 
                el2 =>
                {
                    el2.Species.Should().Be(AnimalSpeciesEnum.Lion);
                    el2.Name.Should().Be("Nala");
                    el2.Weight.Should().Be(172);
                }, 
                el3 =>
                {
                    el3.Species.Should().Be(AnimalSpeciesEnum.Lion);
                    el3.Name.Should().Be("Mufasa");
                    el3.Weight.Should().Be(190);
                }, 
                el4 =>
                {
                    el4.Species.Should().Be(AnimalSpeciesEnum.Tiger);
                    el4.Name.Should().Be("Dante");
                    el4.Weight.Should().Be(150);
                }, 
                el5 =>
                {
                    el5.Species.Should().Be(AnimalSpeciesEnum.Tiger);
                    el5.Name.Should().Be("Asimov");
                    el5.Weight.Should().Be(142);
                },
                el6 =>
                {
                    el6.Species.Should().Be(AnimalSpeciesEnum.Tiger);
                    el6.Name.Should().Be("Tolkien");
                    el6.Weight.Should().Be(139);
                }, 
                el7 =>
                {
                    el7.Species.Should().Be(AnimalSpeciesEnum.Giraffe);
                    el7.Name.Should().Be("Hanna");
                    el7.Weight.Should().Be(200);
                }, 
                el8 =>
                {
                    el8.Species.Should().Be(AnimalSpeciesEnum.Giraffe);
                    el8.Name.Should().Be("Anna");
                    el8.Weight.Should().Be(202);
                }, 
                el9 =>
                {
                    el9.Species.Should().Be(AnimalSpeciesEnum.Giraffe);
                    el9.Name.Should().Be("Susanna");
                    el9.Weight.Should().Be(199);
                }, 
                el10 =>
                {
                    el10.Species.Should().Be(AnimalSpeciesEnum.Zebra);
                    el10.Name.Should().Be("Chip");
                    el10.Weight.Should().Be(100);
                }, 
                el11 =>
                {
                    el11.Species.Should().Be(AnimalSpeciesEnum.Zebra);
                    el11.Name.Should().Be("Dale");
                    el11.Weight.Should().Be(62);
                }, 
                el12 =>
                {
                    el12.Species.Should().Be(AnimalSpeciesEnum.Wolf);
                    el12.Name.Should().Be("Pin");
                    el12.Weight.Should().Be(78);
                }, 
                el13 =>
                {
                    el13.Species.Should().Be(AnimalSpeciesEnum.Wolf);
                    el13.Name.Should().Be("Pon");
                    el13.Weight.Should().Be(69);
                }, 
                el14 =>
                {
                    el14.Species.Should().Be(AnimalSpeciesEnum.Piranha);
                    el14.Name.Should().Be("Anastasia");
                    el14.Weight.Should().Be(0.5m);
                });


        }
    }
}
