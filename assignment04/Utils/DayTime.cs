namespace assignment04.Utils;

public struct DayTime
{
    private readonly long minutes;

    public DayTime(long minutes)
    {
        this.minutes = minutes;
    }

    public static DayTime operator +(DayTime lhs, int minutes)
    {
        return new DayTime(lhs.minutes + minutes);
    }

    public override string ToString()
    {
        // YYYY-MM-DD HH:mm
        var month = minutes % 518_400 / 43_200;
        var Month = Convert.ToInt32(month).ToString();
        if (Month.Length == 1)
            Month = "0" + Month;
        return $"{minutes / 518_400}-" +
               $"{Month}-" +
               $"{minutes % 518_400 % 43_200 / 1_440} " +
               $"{minutes % 518_400 % 43_200 % 1_440 / 60}: " +
               $"{minutes % 518_400 % 43_200 % 1_440 % 60}";
    }
}