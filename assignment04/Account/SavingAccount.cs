using assignment04.Exception;

namespace assignment04.Account;

public class SavingAccount : Account
{
    private const int MONTH = 12;
    private static double COST_PER_TRANSACTION = 0.05;
    private static readonly double INTEREST_RATE = 0.015;

    public SavingAccount(double balance = 0) : base("SV-", balance)
    {
        Balance = balance;
    }

    public void Withdraw(double amount, Person person)
    {
        foreach (var item in users)
            if (person.Name != item.Name)
                throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            else if (person.IsAuthenticated == false)
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
            //TODO: ?????
            else if (amount > CreditLimit)
                throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            else
                base.Deposit(-amount, person);
    }

    public void Deposit(double amount, Person person)
    {
        base.Deposit(amount, person);
        base.OnTransactionOccur(amount, person);
    }

    public override void PrepareMonthlyReport()
    {
        double interests;
        interests = INTEREST_RATE * LowestBalance / 12;
        Balance = Balance - interests;
        transactions.Clear();
    }
}