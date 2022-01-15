namespace HelpersToolbox.Extensions
{
    public static class BoolExtensions
    {
        public static string AsYesNo(this bool? value)
        {
            if (value.HasValue && value.Value)
                return "Yes";
            if (value.HasValue)
                return "No";
            return "N/A";
        }

        public static string AsYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }
    }
}