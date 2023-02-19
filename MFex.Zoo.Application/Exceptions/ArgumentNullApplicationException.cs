using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.Application.Exceptions
{
    public class ArgumentNullApplicationException: Exception
    {
        public ArgumentNullApplicationException(string message):base(message)
        {

        }
    }
}
