namespace CompanyEmployee.Business.Exceptions;

public class NotEmptyException:Exception
{
    public NotEmptyException(string message):base(message)
    {
        
    }
}
