namespace assignment04.Transaction;

public interface ITransaction
{
    void Withdraw(double amount, Person person);
    void Deposit(double amount, Person person);
}