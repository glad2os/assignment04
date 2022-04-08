using System.Xml.Schema;

namespace assignment04.Account;

public abstract class Account
{
    private static int LAST_NUMBER = 100_000;
    protected readonly List<Person> users;
    public readonly List<Transaction> transactions;

    public EventHandler<EventArgs> OnTransaction;
    
    public string Number { get; }
    public double Balance { get; protected set; }
    public double LowestBalance { get; protected set; }

    public Account(string type, double balance)
    {
        Number = type + "-" + LAST_NUMBER;
        Balance = balance;
        LowestBalance = balance;
        transactions = new List<Transaction>();
        users = new List<Person>();
    }

    public void Deposit(double amount, Person person)
    {
        Balance += amount;
        LowestBalance = Balance;
        transactions.Add(new Transaction(AccountNumber = Number, Amount = amount, Originator = person));
    }

    public void AddUser(Person person)
    {
        users.Add(person);
    }

    public bool IsUser(string name)
    {
        var match = users.Any(x => name == users.Name);
        if (match == true)
            return true;
        else
            return false;
    }

    public abstract void PrepareMonthlyReport();
    
    public virtual void OnTransactionOccur(object sender, EventArgs args)
    {
        OnTransaction(sender, args);
    }

    public override string ToString()
    {
        return $"{Number} {users.Name} {Balance:C} {transactions}";
    }
}