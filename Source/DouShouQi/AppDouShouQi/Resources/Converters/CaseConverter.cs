using DouShouQiLib;
using System.Globalization;

namespace AppDouShouQi.Resources.Converters;

public class CaseColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        CaseType type = (CaseType)value!;
        switch (type)
        {
            case CaseType.Terre:
                return "Yellow";
            case CaseType.Eau:
                return "Blue";
            case CaseType.Piege:
                return "Red";
            case CaseType.Taniere:
                return "Green";
            default: return "DarkSalmon";
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}