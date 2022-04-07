namespace assignment04.Transaction;

public class LoginEventArgs : EventArgs
{
    public string PersonName { get; }
    public bool Success { get; }

    public LoginEventArgs(string personName, bool success)
    {
        PersonName = personName;
        Success = success;
    }
}