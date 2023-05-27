using MediatR;

namespace SimpraApi.Base;
public static class HelperMethods
{
    public static string NormalizeString(this string str)
    {
        str = str.ToLower().Trim();
        str = char.ToUpper(str[0]) + str.Substring(1);
        return str;
    }
    
    public static string Format(this string str, params string[] args)
    {
        return String.Format(str, args);
    }

    public static bool CheckIfOlderThan18(this string date)
    {
        DateTime dateOfBirth;
        if (DateTime.TryParse(date, out dateOfBirth))
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

            return age >= 18;
        }
        return false;
    }

    public static bool IsValidDate(this string date)
    {
        return DateTime.TryParse(date, out _);
    }

    public static bool IsValidUrl(this string url)
    {
        return Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out _);
    }
}
