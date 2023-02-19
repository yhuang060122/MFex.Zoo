using MFex.Zoo.Domain;
using MFex.Zoo.Domain.IRepository;
using MFex.Zoo.Domain.Records;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MFex.Zoo.Infrastructure
{
    public class ZooRepository : IZooRepository
    {
        private readonly string _rootPath;

        // TODO : => appsettings.json
        private const string PRICES_FILE_NAME = "prices.txt";
        private const string ANIMALS_FILE_NAME = "animals.csv";
        private const string ZOO_FILE_NAME = "zoo.xml";

        public ZooRepository(string rootPath)
        {
            _rootPath = rootPath;
        }

        public IReadOnlyList<Food> GetPrices()
        {
            var res = new List<Food>();
            string[] lines = File.ReadAllLines(Path.Combine(_rootPath, PRICES_FILE_NAME));

            foreach (string line in lines)
            {
                string[] strs = line.Split("=");
                var foodType = Enum.Parse<FoodTypeEnum>(strs[0], true);
                var price = decimal.Parse(strs[1], CultureInfo.InvariantCulture);
                res.Add(new Food(foodType, price));
            }

            return res;
        }

        public IReadOnlyList<AnimalFoodRate> GetFoodRates()
        {
            var res = new List<AnimalFoodRate>();
            using (TextFieldParser parser = new TextFieldParser(Path.Combine(_rootPath, ANIMALS_FILE_NAME)))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();

                    var rate = decimal.Parse(fields[1], CultureInfo.InvariantCulture);
                    var species = Enum.Parse<AnimalSpeciesEnum>(fields[0], true);
                    if (string.Equals("both", fields[2], StringComparison.OrdinalIgnoreCase))
                    {
                        var meatCoverage = decimal.Parse(fields[3].TrimEnd('%'), CultureInfo.InvariantCulture) / 100;
                        res.Add(new AnimalFoodRate(species, FoodTypeEnum.Meat, rate * meatCoverage));
                        res.Add(new AnimalFoodRate(species, FoodTypeEnum.Fruit, rate * (1 - meatCoverage)));
                    }
                    else
                    {
                        var foodType = Enum.Parse<FoodTypeEnum>(fields[2], true);
                        res.Add(new AnimalFoodRate(species, foodType, rate));
                    }
                }
            }

            return res;
        }

        public IReadOnlyList<AnimalWeight> GetAnimalWeights()
        {
            var res = new List<AnimalWeight>();
            XElement zoo = XElement.Load(Path.Combine(_rootPath, ZOO_FILE_NAME));
            AnimalSpeciesEnum[] species = (AnimalSpeciesEnum[])Enum.GetValues(typeof(AnimalSpeciesEnum));
            foreach (var spec in species)
            {
                var animals = zoo.Descendants(spec.ToString());
                foreach(var animal in animals)
                {
                    var name = animal.Attribute("name").Value;
                    var kg = decimal.Parse(animal.Attribute("kg").Value, CultureInfo.InvariantCulture);

                    res.Add(new AnimalWeight(spec, name, kg));
                }
            }
            return res;
        }
    }
}
