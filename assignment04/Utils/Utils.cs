using assignment04.Account;

namespace assignment04.Utils;

public class Utils
{
    private static DayTime _time = new((long) 1_048_000_000);
    private static readonly Random Random = new();

    public static readonly Dictionary<AccountType, string> AccountTypes =
        new()
        {
            {AccountType.Checking, "CK"},
            {AccountType.Saving, "SV"},
            {AccountType.Visa, "VS"}
        };

    public static DayTime Time => _time += Random.Next(1000);

    public static DayTime Now => _time += 0;
}