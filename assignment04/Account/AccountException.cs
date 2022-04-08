namespace assignment04.Account;

public class AccountException : Exception
{
    public AccountException(ExceptionType reason)
    {
        : base(Enum.GetName(typeof(ExceptionType), reason))
        { }
    }
}