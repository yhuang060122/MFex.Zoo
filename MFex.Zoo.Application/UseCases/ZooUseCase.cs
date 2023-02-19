using MFex.Zoo.Application.Interfaces;
using MFex.Zoo.Domain;
using MFex.Zoo.Domain.IRepository;
using MFex.Zoo.Domain.Records;

namespace MFex.Zoo.Application.UseCases
{
    public class ZooUseCase : IZooUseCase
    {
        private readonly IZooRepository _repo;

        public ZooUseCase(IZooRepository repo)
        {
            _repo = repo;
        }

        public decimal CalculSpends()
        {
            var animals = new List<Animal>();
            
            var dictAnimalFoodRates = GetDictAnimalFoodRates();

            var animalWeights = _repo.GetAnimalWeights();

            foreach (var animal in animalWeights)
            {
                var toAdd = new Animal(animal.Species, animal.Name, animal.Weight, dictAnimalFoodRates[animal.Species]);
                animals.Add(toAdd);
            }

            return animals.Sum(a => a.CalculSpendsPerDay());
        }

        private IDictionary<AnimalSpeciesEnum, List<FoodRate>> GetDictAnimalFoodRates()
        {
            var res = new Dictionary<AnimalSpeciesEnum, List<FoodRate>>();
            var foodPrices = _repo.GetPrices();
            var foodRates = _repo.GetFoodRates();

            var pricesDict = foodPrices.ToDictionary(p => p.FoodType, p => p);


            foreach (var rate in foodRates)
            {
                if (!res.ContainsKey(rate.Species))
                    res[rate.Species] = new List<FoodRate>();

                res[rate.Species].Add(new FoodRate(pricesDict[rate.FoodType], rate.Rate));
            }

            return res;
        }

    }
}
