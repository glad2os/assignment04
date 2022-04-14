namespace assignment04.Transaction;

public class TransactionEventArgs : LoginEventArgs
{
    public TransactionEventArgs(string personName, double amount, bool success) : base(personName, success)
    {
        Amount = amount;
    }

    public double Amount { get; }
}