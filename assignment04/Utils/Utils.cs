using assignment04.Account;

namespace assignment04;

public class Utils
{
    private static DayTime _time = new(1_048_000_000);
    private static readonly Random random = new();

    public static readonly Dictionary<AccountType, string> ACCOUNT_TYPES =
        new()
        {
            {AccountType.Checking, "CK"},
            {AccountType.Saving, "SV"},
            {AccountType.Visa, "VS"}
        };

    public static DayTime Time => _time += random.Next(1000);

    public static DayTime Now => _time += 0;
}