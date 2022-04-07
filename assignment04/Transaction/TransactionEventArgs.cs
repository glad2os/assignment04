namespace assignment04.Transaction;

public class TransactionEventArgs : LoginEventArgs
{
    public double Amount { get; }
    
    public TransactionEventArgs(string personName, double amount, bool success) : base(personName, success)
    {
    }
}