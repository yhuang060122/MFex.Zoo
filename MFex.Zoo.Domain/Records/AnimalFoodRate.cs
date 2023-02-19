using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.Domain.Records
{
    public record AnimalFoodRate(AnimalSpeciesEnum Species, FoodTypeEnum FoodType, decimal Rate);

}
