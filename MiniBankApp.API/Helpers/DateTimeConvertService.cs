using System.Globalization;
using MiniBankApp.API.Helpers.Base;

namespace MiniBankApp.API.Helpers;

public class DateTimeConvertService : IDateTimeConvert
{
    private const string cultureInfoStr = "ru-RU";
    
    public DateTime GetDateTime(string dateTime)
    {
        try
        {
            CultureInfo cultureInfo = new CultureInfo(cultureInfoStr);
            return Convert.ToDateTime(dateTime, cultureInfo);
        }
        catch (Exception ex)
        {
            throw new FormatException();
        }
    }
}