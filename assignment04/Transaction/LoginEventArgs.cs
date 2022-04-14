namespace assignment04.Transaction;

public class LoginEventArgs : EventArgs
{
    public LoginEventArgs(string personName, bool success)
    {
        PersonName = personName;
        Success = success;
    }

    public string PersonName { get; }
    public bool Success { get; }
}