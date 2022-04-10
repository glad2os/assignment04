using assignment04.Exception;

namespace assignment04.Account;

public class VisaAccount : Account
{
    private const int MONTH = 12;
    private static readonly double INTEREST_RATE = 0.1995;
    private double creditLimit;

    public VisaAccount(double balance = 0, double creditLimit = 1200) : base("VS-", balance)
    {
        this.creditLimit = creditLimit;
    }

    public void DoPayment(double amount, Person person)
    {
        Deposit(amount, person);
        base.OnTransactionOccur(amount, person);
    }

    public void DoPurchase(double amount, Person person)
    {
        foreach (var item in users)
            if (person.Name != item.Name)
                throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            else if (person.IsAuthenticated == false)
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
            else if (amount > creditLimit)
                throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            else
                Deposit(-amount, person);
    }


    public override void PrepareMonthlyReport()
    {
        var interests = INTEREST_RATE * LowestBalance / 12;
        Balance = Balance - interests;
        transactions.Clear();
    }
}