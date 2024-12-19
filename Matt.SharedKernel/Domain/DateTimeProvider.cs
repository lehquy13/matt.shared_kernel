namespace Matt.SharedKernel.Domain;

public static class DateTimeProvider
{
    private static DateTime? _currentTime;

    public static DateTime Now => DateTimeProvider._currentTime ?? DateTime.Now;

    public static void Set(DateTime currentTime)
    {
        DateTimeProvider._currentTime = new DateTime?(currentTime);
    }

    public static void Reset() => DateTimeProvider._currentTime = new DateTime();
}