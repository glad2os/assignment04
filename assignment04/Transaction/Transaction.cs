namespace assignment04.Transaction;

public struct Transaction
{
    public string AccountNumber { get; }
    public double Amount { get; }
    public Person Originator { get; }
    public DayTime Time { get; }

    public Transaction(string accountNumber, double amount, Person originator, DayTime time)
    {
        AccountNumber = accountNumber;
        Amount = amount;
        Originator = originator;
        Time = time;
    }
    public override string ToString()
    {
        //TODO: This method overrides the same method of the Object class.
        //It does not take any parameter and it returns a string representing
        //the account number, name of the person, the amount, and the time that
        //this transition was completed. [See the output for clues for this method.]
        //You must include the word Deposit or Withdraw in the output.

        return $"AccountNumber = {AccountNumber}, Amount={Amount}, Originator={Originator}, Time={Time}";
    }
}