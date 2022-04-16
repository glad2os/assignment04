using assignment04.Exception;
using assignment04.Transaction;

namespace assignment04.Account;

public class CheckingAccount : Account, ITransaction
{
    private static double COST_PER_TRANSACTION = 0.05;
    private static readonly double INTEREST_RATE = 0.005;
    private static readonly string TYPE = Utils.Utils.ACCOUNT_TYPE[AccountType.Checking];
    private bool hasOverdraft;

    public CheckingAccount(double balance = 0, bool hasOverdraft = false) : base($"{TYPE}-", balance)
    {
        this.hasOverdraft = hasOverdraft;
    }

    public void Withdraw(double amount, Person person)
    {
        var exists = users.Exists(p => p.Equals(person));
        if (!exists)
        {
            OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, false));
            throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
        }

        if (!person.IsAuthenticated)
        {
            OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, false));
            throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
        }

        if (amount > Balance && !hasOverdraft)
        {
            OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, false));
            throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
        }

        OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, true));
        base.Deposit(-amount, person);
    }

    public new void Deposit(double amount, Person person)
    {
        base.Deposit(amount, person);
        base.OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, true));
    }

    public override void PrepareMonthlyReport()
    {
        var serviceCharge = transactions.Count * COST_PER_TRANSACTION;
        var interest = LowestBalance * INTEREST_RATE / 12;
        Balance += interest - serviceCharge;
        transactions.Clear();
    }
}