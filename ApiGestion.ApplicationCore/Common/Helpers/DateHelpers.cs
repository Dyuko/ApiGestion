namespace ApiGestion.ApplicationCore.Common.Helpers;
public static class DateHelpers
{
    public static bool BeAValidDate(DateTime date) =>
        date != default;
}