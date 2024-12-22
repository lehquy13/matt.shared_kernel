namespace Matt.SharedKernel.Domain;

public static class DateTimeProvider
{
    private static DateTime? _currentTime;

    public static DateTime Now => _currentTime ?? DateTime.Now;

    public static void Set(DateTime currentTime)
    {
        _currentTime = currentTime;
    }

    public static void Reset() => _currentTime = new DateTime();
}