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
            foreach (var item in base.users)
            {
                if (person.Name != item.Name)
                {
                    base.OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, false));
                    throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
                }
                else if (person.IsAuthenticated == false)
                {
                    base.OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, false));
                    throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                }
                else if (amount > CreditLimit)
                {
                    base.OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, false));
                    throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
                }
                else
                {
                    base.OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, true));
                    base.Deposit(-amount, person);
                }
            }
        }

    public void Deposit(double amount, Person person)
    {
        base.Deposit(amount, person);
        base.OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, true));
    }
   
        public override void PrepareMonthlyReport()
        {
            double interests;
            interests = INTEREST_RATE * LowestBalance / 12;
            Balance = Balance - interests;
            transactions.Clear();
        }
    }
}