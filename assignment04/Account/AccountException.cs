using assignment04.Exception;

namespace assignment04.Account;

public class AccountException : System.Exception
{
    public override string Message { get; }

    public AccountException(ExceptionEnum message) : base(message.ToString())
    {
        Message = message.ToString();
    }
}