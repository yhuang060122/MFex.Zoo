using MFex.Zoo.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.Domain
{

    public class Animal
    {
        public AnimalSpeciesEnum Species { get; private set; }
        public string Name { get; private set; }
        public decimal Weight { get; private set; }
        public IReadOnlyCollection<FoodRate> Foods { get; private set; }

        public Animal(AnimalSpeciesEnum species, string name, decimal weight, List<FoodRate> foods)
        {
            Species = species;
            Name = name;
            Weight = weight;
            Foods = foods;
        }

        public decimal CalculSpendsPerDay()
        {
            var spends = 0m;

            foreach(var food in Foods)
            {
                spends += Weight * food.Rate * food.Food.Price;
            }

            return spends;
        }
    }
}
