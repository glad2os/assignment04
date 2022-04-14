namespace assignment04.Account 
{

    public class VisaAccount : Account
    {
        private double creditLimit;
        private static double INTEREST_RATE = 0.1995;
        private const int MONTH = 12;

        public VisaAccount(double balance = 0, double creditLimit = 1200) : base("VS-", balance)
        {
            this.creditLimit = creditLimit;
        }

        public void DoPayment(double amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.ToString(), amount, true));
        }

        public void DoPurchase(double amount, Person person)
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

        
        public override void PrepareMonthlyReport()
        {
            double interests;
            interests = INTEREST_RATE * LowestBalance / 12;
            Balance = Balance - interests;
            transactions.Clear();
        }
    }
}