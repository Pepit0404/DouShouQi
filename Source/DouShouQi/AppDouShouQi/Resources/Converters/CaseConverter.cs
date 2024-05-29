using DouShouQiLib;
using System.Globalization;

namespace AppDouShouQi.Resources.Converters;

public class CaseColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        CaseType type = (CaseType)value!;
        return type switch
        {
            CaseType.Terre => "Yellow",
            CaseType.Eau => "Blue",
            CaseType.Piege => "Red",
            CaseType.Taniere => "Green",
            _ => "DarkSalmon",
        };
    }


    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class CaseImageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        CaseType type = (CaseType)value!;
        return type switch
        {
            CaseType.Terre => "terre.jfif",
            CaseType.Eau => "eau.jpg",
            CaseType.Piege => "piege.jpg",
            CaseType.Taniere => "taniere.jpg",
            _ => null,
        };
    }
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}