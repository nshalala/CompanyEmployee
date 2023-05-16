using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployee.Business.Helpers;

public class Helper
{
    public static Dictionary<string, string> Exceptions { get; set; } = new Dictionary<string, string>()
    {
        {"AlreadyExistsException","This object already exists." },
        {"CapacityLimitException","Capacity is already full." },
        {"InvalidWordException","Entered word is not valid. Use only letters." },
        {"NotEmptyException","Object should be empty to perform the operation." },
        {"TooLowException","Entered value is too low." },
        {"SizeException","Length is too short." },
        {"NegativeValueException","Enter a non-negative value." }
    };
}
