using assignment04.Utils;

namespace assignment04.Transaction;

public struct Transaction
{
    public string AccountNumber { get; }
    public double Amount { get; }
    public Person Originator { get; }
    public DayTime Time { get; }

    public Transaction(string accountNumber, double amount, Person person, DayTime dayTime)
    {
        AccountNumber = accountNumber;
        Amount = amount;
        Originator = person;
        Time = Utils.Utils.Now;
    }

    public override string ToString()
    {
        return $"AccountNumber = {AccountNumber}, Amount={Amount}, Originator={Originator}, Time={Time}";
    }
}