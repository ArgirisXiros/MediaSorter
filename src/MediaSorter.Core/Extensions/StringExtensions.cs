using MediaSorter.Core.Enumerations;

namespace MediaSorter.Core.Extensions;

public static class StringExtensions
{
    public static ContentType ToContentType(this string value, ContentType defaultType = ContentType.undefined)
    {
        if (string.IsNullOrEmpty(value))
            return defaultType;

        var lastPart = value.Split(".").Last();

        if (Enum.TryParse(lastPart, ignoreCase: true, out ContentType type))
            return type;

        return defaultType;
    }
}
