namespace assignment04.Account;

public class AccountException : System.Exception
{
    public AccountException(string message)
    {
        Message = message;
    }

    public override string Message { get; }
}