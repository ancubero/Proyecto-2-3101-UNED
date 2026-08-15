using System.Globalization;

namespace Proyecto_2_3101.Extensions;

public static class MonetaryFormatExtension
{

    private static readonly CultureInfo CrCulture = new CultureInfo("es-CR");
    
    public static string FormatColones(this decimal value)
    {
        return value.ToString("C", CrCulture);
    }
    
    public static string FormatColones(this decimal? value)
    {
        return value.HasValue ? value.Value.ToString("C", CrCulture) : "¢0.00";
    }
    
    
}