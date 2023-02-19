using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.Domain.Records
{
    public record Food(FoodTypeEnum FoodType, decimal Price);
}
