namespace CompanyEmployee.Business.Exceptions;

public class NegativeValueException:Exception
{
    public NegativeValueException(string message):base(message)
    {
        
    }
}
