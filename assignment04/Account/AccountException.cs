namespace assignment04.Account;

public class AccountException : System.Exception
{
    public AccountException(AccountEnum message)
    {
        Message = message;
    }

    public override string Message { get; }
}