using MediaSorter.Core.Enumerations;

namespace MediaSorter.Core.Extensions;

public static class StringExtensions
{
    public static MediaType ToMediaType(this string value, MediaType defaultType = MediaType.undefined)
    {
        if (string.IsNullOrEmpty(value))
            return defaultType;

        var lastPart = value.Split(".").Last();

        if (Enum.TryParse(lastPart, ignoreCase: true, out MediaType type))
            return type;

        return defaultType;
    }
}
