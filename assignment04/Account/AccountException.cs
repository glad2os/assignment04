namespace assignment04.Account;

public class AccountException : System.Exception
{
    public AccountException(ExceptionEnum reason)
        : base(Enum.GetName(typeof(ExceptionEnum), reason))
    { }
}