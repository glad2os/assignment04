using assignment04.Transaction;

namespace assignment04;

public static class Logger
{
    private static List<string> loginEvents;
    private static List<string> transactionEvents;

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

    public static void TransactionHandler(object sender, EventArgs args)
    {
        var argObj = (TransactionEventArgs) args;

        var str = $"PersonName={argObj.PersonName} ";
        str += $"Amount ={argObj.Amount} ";
        //TODO: THE OPERATION METHOD IS NOT IMPLEMENTED IN THE DOCUMENT!!!!
        // str += $"Operation ={argObj.Operation} ";
        str += $"Success ={argObj.Success} ";
        str += $"Current time ={Utils.Utils.Time} ";
        transactionEvents.Add(str);
    }

    public static void LoginHandler(object sender, EventArgs args)
    {
        var objectArgs = (LoginEventArgs) args;
        var str = string.Empty;
        str += $"PersonName={objectArgs.PersonName}";
        str += $"Success ={objectArgs.Success} ";
        str += $"Current time ={Utils.Utils.Time} ";
        loginEvents.Add(str);
    }
}