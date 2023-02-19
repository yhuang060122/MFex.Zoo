using MFex.Zoo.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.Domain.IRepository
{
    public interface IZooRepository
    {
        IReadOnlyList<Food> GetPrices();
        IReadOnlyList<AnimalFoodRate> GetFoodRates();
        IReadOnlyList<AnimalWeight> GetAnimalWeights();
    }
}
