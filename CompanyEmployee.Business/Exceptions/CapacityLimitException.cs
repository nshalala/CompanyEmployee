namespace CompanyEmployee.Business.Exceptions;

public class CapacityLimitException:Exception
{
    public CapacityLimitException(string message):base(message)
    {
        
    }
}
