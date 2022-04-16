using assignment04.Transaction;

namespace assignment04;

public static class Logger
{
    private static List<string> loginEvents = new();
    private static List<string> transactionEvents = new();

    public static void ShowTransactionEvents()
    {
        Console.WriteLine(Utils.Utils.Time);

        foreach (var loginEvent in transactionEvents)
            Console.WriteLine(loginEvent);
    }

    public static void ShowLoginEvents()
    {
        Console.WriteLine(Utils.Utils.Time);

        foreach (var loginEvent in loginEvents)
            Console.WriteLine(loginEvent);
    }

    public static void TransactionHandler(object? sender, EventArgs args)
    {
        var argObj = args as TransactionEventArgs;

        if (argObj == null)
            throw new System.Exception("TransactionEventArgs is null");

        var str = $"PersonName={argObj.PersonName} ";
        str += $"Amount ={argObj.Amount} ";
        var operation = argObj.Amount > 0 ? '+' : '-';
        str += $"Operation ={operation}";
        str += $"Success ={argObj.Success} ";
        str += $"Current time ={Utils.Utils.Time} ";
        transactionEvents.Add(str);
    }

    public static void LoginHandler(object? sender, EventArgs args)
    {
        var objectArgs = args as LoginEventArgs;

        var str = string.Empty;

        if (objectArgs == null)
            throw new System.Exception("LoginEventArgs is null");

        str += $"PersonName={objectArgs.PersonName}";
        str += $"Success ={objectArgs.Success} ";
        str += $"Current time ={Utils.Utils.Now} ";
        loginEvents.Add(str);
    }
}