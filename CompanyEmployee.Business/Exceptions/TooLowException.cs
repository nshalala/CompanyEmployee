using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployee.Business.Exceptions;

public class TooLowException:Exception
{
    public TooLowException(string message):base(message)
    {
        
    }
}
