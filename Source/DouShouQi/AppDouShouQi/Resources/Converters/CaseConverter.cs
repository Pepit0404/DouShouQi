using DouShouQiLib;
using System.Diagnostics;
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
            CaseType.Piege => "piege.jpeg",
            CaseType.Taniere => "taniere.jpeg",
            _ => null,
        };
    }
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class PieceColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null) return null;
        Piece p = (Piece)value!;
        return p.Proprietaire.Id switch
        {
            1 => "Blue",
            2 => "Red",
            _ => "DarkSalmon",
        };
    }
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class PieceImageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null) return null;
        Piece p = (Piece)value!;
        return p.Type switch
        {
            PieceType.souris => "souris.png",
            PieceType.chat => "chat.png",
            PieceType.chien => "chien.png",
            PieceType.loup => "loup.png",
            PieceType.leopard => "leopard.png",
            PieceType.tigre => "tigre.png",
            PieceType.lion => "lion.png",
            PieceType.elephant => "elephant.png",
            _ => null,
        };
    }
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class JoueurColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null) return null;
        Joueur j = (Joueur)value!;
        return j.Id switch
        {
            1 => "Blue",
            2 => "Red",
            _ => "DarkSalmon",
        };
    }
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}