namespace Proyecto_2_3101.Extensions;

public static class DateTimeExtension
{
    //En caso de traer un valor nulo
    public static string FormatDate(this DateTimeOffset? date)
    {
        if(!date.HasValue) return "--";
        return date.Value.Year <= 1 ? "--" : date.Value.ToString("dd/MM/yyyy hh:mm tt");
    }
    
    //En caso de no tener valor nulo
    public static string FormatDate(this DateTimeOffset date)
    {
        return date.Year <= 1 ? "--" : date.ToString("dd/MM/yyyy hh:mm tt");
    }
    
    public static string HoursAndMinutes(this TimeSpan? duration)
    {
        return !duration.HasValue ? "00:00" : duration.Value.HoursAndMinutes();
    }
    
    private static string HoursAndMinutes(this TimeSpan duration)
    {
        var hours = (int)duration.TotalHours;
        var minutes = duration.Minutes;
        return $"{hours:D2}:{minutes:D2}";
    }
}