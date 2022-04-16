using assignment04.Exception;
using assignment04.Transaction;

namespace assignment04.Account
{
    public class VisaAccount : Account, ITransaction
    {
        private double creditLimit;
        private static double INTEREST_RATE = 0.1995;
        private static readonly string TYPE = Utils.Utils.ACCOUNT_TYPE[AccountType.Visa];

        public VisaAccount(double balance = 0, double creditLimit = 1200) : base($"{TYPE}-", balance)
        {
            this.creditLimit = creditLimit;
        }

        public void DoPayment(double amount, Person person)
        {
            Deposit(amount, person);
            OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, true));
        }

        public void DoPurchase(double amount, Person person)
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

            if (amount > Balance + creditLimit)
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, false));
                throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }

            OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, true));
            Deposit(-amount, person);
        }

        public override void PrepareMonthlyReport()
        {
            var interest = LowestBalance * INTEREST_RATE / 12;
            Balance -= interest;
            transactions.Clear();
        }

        public void Withdraw(double amount, Person person)
        {
            Deposit(-amount, person);
        }
    }
}