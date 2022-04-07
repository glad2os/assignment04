namespace assignment04.Account 
{ 

public class SavingAccount : Account
{
    private static double COST_PER_TRANSACTION = 0.05;
    private static double INTEREST_RATE = 0.015;
    private const int MONTH = 12;

    public SavingAccount(double balance = 0) : base("SV-", balance)
    {
        Balance = balance;
    }

    public void Withdraw(double amount, Person person)
    {
        if (!this.IsUser(person.Name)) throw new AccountException(AccountException.ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
        if (!person.IsAuthenticated) throw new AccountException(AccountException.ExceptionEnum.USER_NOT_LOGGED_IN);
        if (this.Balance < amount) throw new AccountException(AccountException.ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
        base.Deposit(-amount, person);

    }

    public void Deposit(double amount, Person person)
    {
        base.Deposit(amount, person);
    }
    public override void PrepareMonthlyStatement()
    {
        var serviceFee = this.transactions.Count * COST_PER_TRANSACTION;
        var interest = this.LowestBalance * (INTEREST_RATE / MONTH);
        this.Balance += interest - serviceFee;
        this.transactions.Clear();
    }
 }
}