using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Axxes.EfCore.Workshop.Data.Database.ValueConverters;

public class DateOnlyToDateTimeConverter() : ValueConverter<DateOnly, DateTime>(
    dateOnly => ConvertTo(dateOnly),
    dateTime => ConvertFrom(dateTime))
{
    private static DateTime ConvertTo(DateOnly from)
    {
        return from.ToDateTime(TimeOnly.MinValue);
    }

    private static DateOnly ConvertFrom(DateTime from)
    {
        return DateOnly.FromDateTime(from);
    }
}