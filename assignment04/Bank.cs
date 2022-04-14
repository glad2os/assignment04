using assignment04.Account;
using assignment04.Exception;

namespace assignment04;

public static class Bank
{
    public static Dictionary<string, Account.Account> Accounts = new();
    public static Dictionary<string, Person> Users = new();

    static Bank()
    {
        //initialize the USERS collection
        AddPerson("Narendra", "1234-5678"); //0
        AddPerson("Ilia", "2345-6789"); //1
        AddPerson("Mehrdad", "3456-7890"); //2
        AddPerson("Vijay", "4567-8901"); //3
        AddPerson("Arben", "5678-9012"); //4
        AddPerson("Patrick", "6789-0123"); //5
        AddPerson("Yin", "7890-1234"); //6
        AddPerson("Hao", "8901-2345"); //7
        AddPerson("Jake", "9012-3456"); //8
        AddPerson("Mayy", "1224-5678"); //9
        AddPerson("Nicoletta", "2344-6789"); //10

        //initialize the ACCOUNTS collection
        AddAccount(new VisaAccount()); //VS-100000
        //TODO: An item with the same key has already been added. Key: VS--100000
        AddAccount(new VisaAccount(150, -500)); //VS-100001
        AddAccount(new SavingAccount(5000)); //SV-100002
        AddAccount(new SavingAccount()); //SV-100003
        AddAccount(new CheckingAccount(2000)); //CK-100004
        AddAccount(new CheckingAccount(1500, true)); //CK-100005
        AddAccount(new VisaAccount(50, -550)); //VS-100006
        AddAccount(new SavingAccount(1000)); //SV-100007

        //associate users with accounts
        var number = "VS-100000";
        AddUserToAccount(number, "Narendra");
        AddUserToAccount(number, "Ilia");
        AddUserToAccount(number, "Mehrdad");
        number = "VS-100001";
        AddUserToAccount(number, "Vijay");
        AddUserToAccount(number, "Arben");
        AddUserToAccount(number, "Patrick");
        number = "SV-100002";
        AddUserToAccount(number, "Yin");
        AddUserToAccount(number, "Hao");
        AddUserToAccount(number, "Jake");
        number = "SV-100003";
        AddUserToAccount(number, "Mayy");
        AddUserToAccount(number, "Nicoletta");
        number = "CK-100004";
        AddUserToAccount(number, "Mehrdad");
        AddUserToAccount(number, "Arben");
        AddUserToAccount(number, "Yin");
        number = "CK-100005";
        AddUserToAccount(number, "Jake");
        AddUserToAccount(number, "Nicoletta");
        number = "VS-100006";
        AddUserToAccount(number, "Ilia");
        AddUserToAccount(number, "Vijay");
        number = "SV-100007";
        AddUserToAccount(number, "Patrick");
        AddUserToAccount(number, "Hao");
    }

    public static Person GetPerson(string name)
    {
        if (Users.ContainsKey(name))
            return Users[name];

        throw new AccountException(ExceptionEnum.USER_DOES_NOT_EXIST);
    }

    public static Account.Account GetAccount(string number)
    {
        if (Accounts.ContainsKey(number))
            return Accounts[number];
        throw new AccountException(ExceptionEnum.ACCOUNT_DOES_NOT_EXIST);
    }

    public static void PrintPersons()
    {
        foreach (var user in Users) Console.WriteLine(user);
    }

    public static void PrintAccounts()
    {
        foreach (var account in Accounts) Console.WriteLine(account);
    }

    public static void AddPerson(string name, string sin)
    {
        var person = new Person(name, sin);

        // TODO : Fix logger
        // person.OnLogin += Logger.LoginHandler(null, person);

        Users.Add(name, person);
    }

    public static void AddAccount(Account.Account account)
    {
        //TODO: no args represented in the task

        // account.OnTransaction += Logger.TransactionHandler(null, n);

        Accounts.Add(account.Number, account);
    }

    public static void AddUserToAccount(string number, string name)
    {
        var account = Accounts[number];
        var person = Users[name];

        account.addUser(person);
    }

    public static List<Transaction.Transaction> GetAllTransactions()
    {
        var result = new List<Transaction.Transaction>();

        foreach (var keyValuePair in Accounts)
        {
            result.AddRange(keyValuePair.Value.transactions);
        }

        return result;
    }
}