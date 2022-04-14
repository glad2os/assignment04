using assignment04.Utils;

namespace assignment04.Account;

public abstract class Account
{
    private int LAST_NUMBER = 100_000;
    public readonly List<Transaction.Transaction> transactions;
    protected readonly List<Person> users;

    public virtual EventHandler<EventArgs> OnTransaction { get; protected internal set; }

    public Account(string type, double balance)
    {
        Number = type + "-" + LAST_NUMBER;
        Balance = balance;
        LowestBalance = balance;
        transactions = new List<Transaction.Transaction>();
        users = new List<Person>();
    }

    public string Number { get; }
    public double Balance { get; protected set; }
    public double LowestBalance { get; protected set; }

    public void Deposit(double amount, Person person)
    {
        Balance += amount;
        LowestBalance = Balance;
        transactions.Add(new Transaction.Transaction(Number, amount, person, new DayTime()));
    }

    public void addUser(Person person)
    {
        users.Add(person);
    }

    public bool IsUser(string name)
    {
        var match = users.Any(x => name == x.Name);
        return match;
    }

    public abstract void PrepareMonthlyReport();

    public virtual void OnTransactionOccur(object sender, EventArgs args)
    {
        OnTransaction(sender, args);
    }

    public override string ToString()
    {
        return $"{Number} {users} {Balance:C} {transactions}";
    }
}